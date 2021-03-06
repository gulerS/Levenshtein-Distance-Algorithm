﻿using System;
using System.Windows.Forms;

namespace LevenshteinAlgoritmasi
{
    public static class LevenshteinDistanceExtention
    {
        public static int FindLevenshteinDistance(this string aranan, string karsilastirilan)
        {
            int n = aranan.Length;
            int m = karsilastirilan.Length;
            int[,] matris = new int[n + 1, m + 1]; // Matrisi Üret
            if (n == 0) // Eğer kaynak metin yoksa zaten hedef metnin tüm harflerinin değişimi söz konusu olduğundan, hedef metnin uzunluğu kadar bir yakınlık değeri mümkün olabilir 
                return m;
            if (m == 0)   
                return n;
            // Aşağıdaki iki döngü ile yatay ve düşey eksenlerdeki standart 0,1,2,3,4...n elemanları doldurulur 
            for (int i = 0; i <= n; i++)
                matris[i, 0] = i;

            for (int j = 0; j <= m; j++)
                matris[0, j] = j;

            // Kıyaslama ve derecelendirme operasyonu
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                {
                    int cost = (karsilastirilan[j - 1] == aranan[i - 1]) ? 0 : 1;
                    matris[i, j] = Math.Min(Math.Min(matris[i - 1, j] + 1, matris[i, j - 1] + 1), matris[i - 1, j - 1] + cost);
                }
            return matris[n, m]; // sağ alt taraftaki hücre değeri döndürülür 
        }

      
    }
}
