namespace LTest.Models.EntityLayer
{
    class Cevap
    {
        public int CevapId { get; set; }

        public int SoruId { get; set; }

        public int TestId { get; set; }

        public string CevapText { get; set; }

        public int Dogru { get; set; }
    }
}
