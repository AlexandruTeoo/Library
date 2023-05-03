namespace EndPointAPI
{
    public class LibraryLoans
    {
        public int LoanId { get; set; }
        public string Username { get; set; }
        public string ISBN { get; set; }

        public DateOnly IssuedDate { get; set; }
        public DateOnly ReturnedDate { get; set; }
    }
}
