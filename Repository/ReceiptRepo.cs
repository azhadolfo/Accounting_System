using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class ReceiptRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceiptRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<string> GenerateCRNo()
        {
            var collectionReceipt = await _dbContext
                .CollectionReceipts
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (collectionReceipt != null)
            {
                var generatedCR = collectionReceipt.Id + 1;
                return $"CR{generatedCR.ToString("D10")}";
            }
            else
            {
                return $"CR{1.ToString("D10")}";
            }
        }

        public async Task<string> GenerateORNo()
        {
            var officialReceipt = await _dbContext
                .OfficialReceipts
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (officialReceipt != null)
            {
                var generatedCR = officialReceipt.Id + 1;
                return $"OR{generatedCR.ToString("D10")}";
            }
            else
            {
                return $"OR{1.ToString("D10")}";
            }
        }

        public async Task<List<CollectionReceipt>> GetCRAsync()
        {
            return await _dbContext
                .CollectionReceipts
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }

        public async Task<List<OfficialReceipt>> GetORAsync()
        {
            return await _dbContext
                .OfficialReceipts
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }

        public async Task<CollectionReceipt> FindCR(int id)
        {
            var collectionReceipt = await _dbContext
                .CollectionReceipts
                .Include(s => s.SalesInvoice)
                .FirstOrDefaultAsync(collectionReceipt => collectionReceipt.Id == id);

            if (collectionReceipt != null)
            {
                return collectionReceipt;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }

        public async Task<OfficialReceipt> FindOR(int id)
        {
            var officialReceipt = await _dbContext
                .OfficialReceipts
                .Include(s => s.StatementOfAccount)
                .ThenInclude(soa => soa.Customer)
                .FirstOrDefaultAsync(collectionReceipt => collectionReceipt.Id == id);

            if (officialReceipt != null)
            {
                return officialReceipt;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }

        //    public string GetAmountInWords(decimal amount)
        //    {
        //        return ConvertAmountToWords(amount);
        //    }
        //    public static string ConvertAmountToWords(decimal amount)
        //    {
        //        if (amount < 0 || amount > 999999999.99m)
        //        {
        //            // Handle out-of-range values as needed
        //            return "Out of range";
        //        }

        //        string[] units = { "", "Thousand", "Million", "Billion" };

        //        int digitGroup = 0;
        //        string amountInWords = "";

        //        do
        //        {
        //            decimal chunk = amount % 1000;
        //            if (chunk != 0)
        //            {
        //                string chunkInWords = ConvertChunkToWords(chunk);
        //                amountInWords = $"{chunkInWords} {units[digitGroup]} {amountInWords}";
        //            }

        //            amount /= 1000;
        //            digitGroup++;
        //        } while (amount > 0);

        //        return amountInWords.Trim();
        //    }

        //    private static string ConvertChunkToWords(decimal chunk)
        //    {
        //        string[] ones =
        //        {
        //    "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
        //    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        //};

        //        string[] tens =
        //        {
        //    "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        //};

        //        string chunkInWords = "";

        //        int hundreds = (int)(chunk / 100);
        //        if (hundreds > 0)
        //        {
        //            chunkInWords += $"{ones[hundreds]} Hundred";
        //        }

        //        int remainder = (int)(chunk % 100);

        //        if (remainder > 0)
        //        {
        //            if (chunkInWords != "")
        //            {
        //                chunkInWords += " and ";
        //            }

        //            if (remainder < 20)
        //            {
        //                chunkInWords += ones[remainder];
        //            }
        //            else
        //            {
        //                chunkInWords += tens[remainder / 10];
        //                if (remainder % 10 > 0)
        //                {
        //                    chunkInWords += $"-{ones[remainder % 10]}";
        //                }
        //            }
        //        }

        //        return chunkInWords;
        //    }
    }
}