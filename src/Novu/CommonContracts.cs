namespace Novu;
public record PaginatedResponse<T>(int Page, int TotalCount, int PageSize, T[] Data);
public record DeleteResponse(DeleteResponseData Data);
public record DeleteResponseData(bool Acknowledged,string Status);
public record AdditionalData(string Key, string Value);