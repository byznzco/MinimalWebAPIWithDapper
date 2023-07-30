namespace MinimalWebAPI.Queries;

public static class StoredProcedures
{
    public static readonly string SP_SELECT_ALL_USERS = @"dbo.EXEC_GET_ALL_USERS";

    public static readonly string SP_SELECT_USER = @"dbo.EXEC_GET_USER";

    public static readonly string SP_DELETE_USER = @"dbo.EXEC_DELETE_USER";

    public static readonly string SP_INSERT_USER = @"dbo.EXEC_INSERT_USER";

    public static readonly string SP_UPDATE_USER = @"dbo.EXEC_UPDATE_USER";

}
