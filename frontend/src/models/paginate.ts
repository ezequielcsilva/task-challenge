export default interface PaginatedResponse<T> {
  data: T[];
  currentPage: number;
  totalPages: number;
  count: number;
  pageSize: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}