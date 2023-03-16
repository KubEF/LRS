using FiniteFields;
namespace LRS
{
    public class CSR
    {
        private int k;
        private PolinomOverSimpleField q;
        private BinaryFiniteField F;
        private FiniteFieldElement[] Coeffs;
        private FiniteFieldElement c;
        private List<FiniteFieldElement> Sequence = new List<FiniteFieldElement>();
        public CSR(FiniteFieldElement[] coeffs, int c, List<FiniteFieldElement> FirstElementsOfSequense)
        {
            if (coeffs.Length == FirstElementsOfSequense.Count)
            {
                k = FirstElementsOfSequense.Count;
                Sequence.AddRange(FirstElementsOfSequense);
                this.q = new PolinomOverSimpleField(new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1 }, 2);
                this.F = new BinaryFiniteField(8, this.q);
                Coeffs = new FiniteFieldElement[k];
                coeffs.CopyTo(Coeffs, 0);
                this.c = F.FromNumberToElement(c);
            }
            else throw new Exception("Неккоректные входные данные");
        }
        public CSR(int[] coeffs, int absoluteTerm, int[] FirstElementsOfSequense)
        {
            if (coeffs.Length == FirstElementsOfSequense.Length)
            {
                k = FirstElementsOfSequense.Length;
                this.q = new PolinomOverSimpleField(new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1 }, 2);
                this.F = new BinaryFiniteField(8, this.q);
                Coeffs = new FiniteFieldElement[k];
                for (int i = 0; i < k; i++)
                {
                    Coeffs[i] = F.FromNumberToElement(coeffs[i]);
                    Sequence.Add(F.FromNumberToElement(FirstElementsOfSequense[i]));
                }
                this.c = F.FromNumberToElement(absoluteTerm);
            }
            else throw new Exception("Неккоректные входные данные");
        }
        public int GetRandom()
        {
            var result = this.F.GetZero();
            for (int i = 0; i < k; i++)
            {
                result = result + Sequence[i] * Coeffs[i];
            }
            result = result + c;
            Sequence.Add(result);
            Sequence.RemoveAt(0);
            return F.FromElementToNumber(result);
        }
    }
}