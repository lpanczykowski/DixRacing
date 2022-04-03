export class Pagination {
  totalRowCount: number;
  totalPages: number;
  currentPage: number;
  itemsPerPage: number;
  constructor(totalRowCount: number, totalPages:number,currentPage:number,itemsPerPage:number)
  {
    this.totalRowCount = totalRowCount;
    this.totalPages = totalPages;
    this.currentPage = currentPage;
    this.itemsPerPage = itemsPerPage;
  }
}

export class PaginatedResult<T> extends Pagination {
  rows: T[];
}
