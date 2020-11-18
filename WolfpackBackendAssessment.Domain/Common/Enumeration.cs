namespace WolfpackBackendAssessment.Domain.Common
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

	public abstract class Enumeration : IComparable
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<object>> _enumCache
            = new ConcurrentDictionary<Type, IEnumerable<object>>();

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get; }

        public string Name { get; }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);

            var values = _enumCache.GetOrAdd(type, _ => type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null)!));

            return values.Cast<T>();
        }

        public static T FromValue<T>(int value) where T : Enumeration
            => Parse<T, int>(value, "value", item => item.Value == value);

        public static T FromName<T>(string name) where T : Enumeration
            => Parse<T, string>(name, "name", item => item.Name == name);

        public static string NameFromValue<T>(int value) where T : Enumeration
            => FromValue<T>(value).Name;

        public static bool HasValue<T>(int value) where T : Enumeration
        {
            try
            {
                FromValue<T>(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool HasName<T>(string name) where T : Enumeration
        {
            try
            {
                FromName<T>(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => (GetType().ToString() + Value).GetHashCode();

        public int CompareTo(object? other) => Value.CompareTo(((Enumeration)other!).Value);

        private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} for {typeof(T).Name}.");

            return matchingItem;
        }
    }
}
