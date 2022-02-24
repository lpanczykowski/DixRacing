namespace DixRacing.Domain.SharedKernel
{
    public static class PaginationOffset
    {
        public static int GetOffset(int pageSize, int pageNumber)
        {
            return(pageNumber-1)*pageSize;
        }
    }
}