export interface PagedList<T> {
  items: T[];
  pageIndex: number;
  pageSize: number;
  totalItems: number;
  totalPages: number;
  isPreviousPage: boolean;
  isNextPage: boolean;
}
