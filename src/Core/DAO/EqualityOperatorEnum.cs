namespace Cortside.Core.DAO {

    /// <summary>
    /// Equality operators for database predicates
    /// </summary>
    public enum EqualityOperatorEnum {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        Like,
        NotLike
    }
}
