using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class QuickSortScript
{
    /*QuickSort för att sortera innehållet som ska visas i Historikscenen.
        Kan sortera efter MaxPromillehalt på en kväll eller efter datum*/
    private static int Partition(List<History> list, int low, int heigh, string type)
    {
        int i = low - 1;
        if (type == "double")
        {
            double pivotDouble = list[heigh].MaxPromille;

            for (int j = low; j <= heigh - 1; j++)
            {
                if (list[j].MaxPromille.CompareTo(pivotDouble) > 0)
                {
                    i++;
                    swapPlace(list, i, j);
                }
            }
        }

        else
        {
            DateTime pivotDate = DateTime.ParseExact((list[heigh].dateCreated), "dd-MM-yyyy HH:mm", null);

            for (int j = low; j <= heigh - 1; j++)
            {
                if (DateTime.Compare(DateTime.ParseExact((list[j].dateCreated), "dd-MM-yyyy HH:mm", null), (pivotDate)) < 0)
                {
                    i++;
                    swapPlace(list, i, j);
                }
            }
        }
        swapPlace(list, i + 1, heigh);
        return (i + 1);
    }

    public static List<History> QuickSort(List<History> hList, int low, int heigh, string type)
    {
        if (hList.Count <= 1)
        {
            return hList;
        }
        if (low < heigh)
        {

            int pivotIndex = Partition(hList, low, heigh, type);
            QuickSort(hList, low, pivotIndex - 1, type);
            QuickSort(hList, pivotIndex + 1, heigh, type);

        }
        return hList;
    }


    private static void swapPlace(List<History> list, int i, int j)
    {
        History temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
