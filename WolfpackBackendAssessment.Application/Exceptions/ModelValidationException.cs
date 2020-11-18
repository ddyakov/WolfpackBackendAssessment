﻿namespace WolfpackBackendAssessment.Application.Exceptions
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	using FluentValidation.Results;

	public class ModelValidationException : Exception
	{
		public ModelValidationException()
			: base("One or more validation errors have occurred.")
			=> Errors = new Dictionary<string, string[]>();

		public ModelValidationException(IEnumerable<ValidationFailure> errors)
			: this()
		{
			var failureGroups = errors
				.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

			foreach (var failureGroup in failureGroups)
			{
				var propertyName = failureGroup.Key;
				var propertyFailures = failureGroup.ToArray();

				Errors.Add(propertyName, propertyFailures);
			}
		}

		public IDictionary<string, string[]> Errors { get; }
	}
}
