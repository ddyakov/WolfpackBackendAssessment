namespace WolfpackBackendAssessment.Application.Common
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class Result
	{
		private readonly List<string> _errors;

		internal Result(bool succeeded, List<string> errors)
		{
			Succeeded = succeeded;
			_errors = errors;
		}

		public bool Succeeded { get; }

		public List<string> Errors
			=> Succeeded
				? new List<string>()
				: _errors;

		public static Result Success
			=> new Result(true, new List<string>());

		public static Result Failure(IEnumerable<string> errors)
			=> new Result(false, errors.ToList());

		public static implicit operator Result(string error)
			=> Failure(new List<string> { error });

		public static implicit operator Result(List<string> errors)
			=> Failure(errors.ToList());

		public static implicit operator Result(bool success)
			=> success ? Success : Failure(new[] { "Unsuccessful operation." });

		public static implicit operator bool(Result result)
			=> result.Succeeded;
	}

	public class Result<TData> : Result
	{
		private readonly TData _data;

		private Result(bool succeeded, TData data, List<string> errors)
			: base(succeeded, errors)
			=> _data = data;

		public TData Data
			=> Succeeded
				? _data
				: throw new InvalidOperationException(
					$"{nameof(Data)} is not available with a failed result. Use {Errors} instead.");

		public static Result<TData> SuccessWith(TData data)
			=> new Result<TData>(true, data, new List<string>());

		public new static Result<TData> Failure(IEnumerable<string> errors)
			=> new Result<TData>(false, default!, errors.ToList());

		public static implicit operator Result<TData>(string error)
			=> Failure(new List<string> { error });

		public static implicit operator Result<TData>(List<string> errors)
			=> Failure(errors);

		public static implicit operator Result<TData>(TData data)
			=> SuccessWith(data);

		public static implicit operator bool(Result<TData> result)
			=> result.Succeeded;
	}
}
