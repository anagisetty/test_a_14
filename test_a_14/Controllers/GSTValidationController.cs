using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace test_a_14
{
    public class GSTValidationController : ApiController
    {
        [HttpPost]
        public bool ValidateGST(string gstNumber)
        {
            if (string.IsNullOrEmpty(gstNumber))
            {
                return false;
            }

            // Check the Check Digit
            int totalDigits = gstNumber.Length;
            if (totalDigits != 15)
            {
                return false;
            }

            // To check the Check Digit, first split the GST Number into parts
            string gstin = gstNumber.Substring(0, 2);
            string panNo = gstNumber.Substring(2, 10);
            string checkDigit = gstNumber.Substring(12, 2);

            // Calculate the Check Digit
            int sum = 0;
            int[] gstinDigits = gstin.Select(c => int.Parse(c.ToString())).ToArray();
            int[] panNoDigits = panNo.Select(c => int.Parse(c.ToString())).ToArray();

            // Calculate the sum
            for (int i = 0; i < gstinDigits.Length; i++)
            {
                sum += (gstinDigits[i] * (i + 2));
            }

            for (int i = 0; i < panNoDigits.Length; i++)
            {
                sum += (panNoDigits[i] * (i + 2));
            }

            int mod = sum % 11;
            int checkDigitValue = 0;
            if (mod != 0)
            {
                checkDigitValue = 11 - mod;
            }

            // Compare the Check Digit
            if (checkDigit != checkDigitValue.ToString())
            {
                return false;
            }

            return true;
        }
    }
}