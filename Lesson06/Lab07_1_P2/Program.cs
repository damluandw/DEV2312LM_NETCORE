using DongVat.AnCo;
using DongVat.AnThit;
using DongVat.AnTap;
namespace Lab07_1_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bo bo = new Bo(11,"Bo",60);
            De de = new De(11, "De", 50);
            Trau trau = new Trau(11, "Trau", 70);
            CaSau caSau = new CaSau(11, "CaSau", 55);
            Ho ho = new Ho(11, "Ho", 40);
            SuTu suTu = new SuTu(11, "SuTu", 30);
            Console.WriteLine("Dong vat an co:");
            Console.WriteLine(bo.ToString());
            Console.WriteLine(de.ToString());
            Console.WriteLine(trau.ToString());
            Console.WriteLine("Dong vat an thit:");
            Console.WriteLine(caSau.ToString());
            Console.WriteLine(ho.ToString());
            Console.WriteLine(suTu.ToString());
        }
    }
}