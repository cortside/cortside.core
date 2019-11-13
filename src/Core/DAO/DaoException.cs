using System;
using System.Runtime.Serialization;

namespace Spring2.Core.DAO {

    /// <summary>
    /// Base exception for DAO exceptions
    /// </summary>
    public class DaoException : System.ApplicationException {

	/// <summary>
	/// Initializes a new instance of the Exception class.
	/// </summary>
	public DaoException() {}

	/// <summary>
	/// Initializes a new instance of the Exception class with a specified error message.
	/// </summary>
	/// <param name="message"></param>
	public DaoException (String message) : base(message) {}

	/// <summary>
	/// Initializes a new instance of the Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message"></param>
	/// <param name="ex"></param>
	public DaoException (String message, Exception ex) : base(message, ex) {}

	/// <summary>
	/// Initializes a new instance of the Exception class with serialized data.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected DaoException(SerializationInfo info, StreamingContext context) : base(info, context) {}

    }
}
