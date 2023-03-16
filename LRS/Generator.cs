using FiniteFields;
namespace LRS
{
    public class CSR
    {
        private readonly int k;
        private readonly BinaryFiniteField F;
        private readonly FiniteFieldElement[] Coeffs;
        private readonly FiniteFieldElement c;
        private readonly List<FiniteFieldElement> Sequence = new List<FiniteFieldElement>();
        public CSR(int[] coeffs, int absoluteTerm, int[] FirstElementsOfSequense)
        {
            if (coeffs.Length == FirstElementsOfSequense.Length)
            {
                k = FirstElementsOfSequense.Length;
                var q = new PolinomOverSimpleField(new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1 }, 2);
                this.F = new BinaryFiniteField(8, q);
                Coeffs = new FiniteFieldElement[k];
                for (int i = 0; i < k; i++)
                {
                    Coeffs[i] = F.FromNumberToElement(coeffs[i]);
                    Sequence.Add(F.FromNumberToElement(FirstElementsOfSequense[i]));
                }
                this.c = F.FromNumberToElement(absoluteTerm);
            }
            else throw new Exception("Некорректные входные данные");
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