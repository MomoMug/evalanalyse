using System;

namespace TriInefficace
{
    class Tris
    {
        /// <summary>
        /// Nombre de comparaisons et inversions dans le tri faire-valoir.
        /// </summary>
        public static int nbTriFaireValoir = 0;

        /// <summary>
        /// Nombre de comparaisons et inversions dans le tri à bulles.
        /// </summary>
        public static int nbTriABulle = 0;

        /// <summary>
        /// Nombre de comparaisons et inversions dans le tri sélection.
        /// </summary>
        public static int nbTriSelection = 0;

        /// <summary>
        /// Permute la valeur des 2 variables en paramètre.
        /// </summary>
        /// <param name="x">La première valeur à permuter.</param>
        /// <param name="y">La deuxième valeur à permuter.</param>
        private static void echanger(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Implémentation du tri faire-valoir.
        /// </summary>
        /// <param name="tableau">Tableau à trier.</param>
        /// <param name="i">Index de départ pour le triage.</param>
        /// <param name="j">Index de fin pour le triage.</param>
        public static void TriFaireValoir(int[] tableau, int i, int j)
        {
            // Si la dernière valeur est plus grande que la première, on 
            // permute
            nbTriFaireValoir++;
            if(tableau[i] > tableau[j])
            {
                nbTriFaireValoir++;
                echanger(ref tableau[i], ref tableau[j]);
            }

            // Si le tableau contient 3 valeurs, on relance le tri 
            // faire-valoir pour le premier 2/3, le dernier 2/3 et finalement 
            // encore le premier 2/3
            nbTriFaireValoir++;
            if(j - i + 1 > 2)
            {
                int t = (j - i + 1) / 3;
                TriFaireValoir(tableau, i, j - t);
                TriFaireValoir(tableau, i + t, j);
                TriFaireValoir(tableau, i, j - t);
            }
        }

        /// <summary>
        /// Implémentation du tri à bulle.
        /// </summary>
        /// <param name="tableau">Tableau à trier.</param>
        public static void TriABulle(int[] tableau)
        {
            // Successivement faire remonter la plus grande valeur du restant 
            // du tableau.
            bool echange;
            for (int i = tableau.Length - 1; i > 0; i--)
            {
                // Remonter la plus grande valeur vers la fin du tableau
                echange = false;
                for (int j = 1; j <= i; j++)
                {
                    nbTriABulle++;
                    if(tableau[j - 1] > tableau[j])
                    {
                        nbTriABulle++;
                        echanger(ref tableau[j - 1], ref tableau[j]);
                        echange = true;
                    }
                }

                // S'il n'y a pas eu de permutation dans la dernière passe, le 
                // tableau est trié, donc on peut arrêter le triage
                nbTriABulle++;
                if(!echange)
                {
                    Console.WriteLine("Il n'y a pas eu permutation");
                    break;
                }
            }
        }

        /// <summary>
        /// Implémentation du tri sélection.
        /// </summary>
        /// <param name="tableau">Tableau à trier.</param>
        public static void TriSelection(int[] tableau)
        {
            // Successivement ramener la plus petite valeur du restant du 
            // tableau
            int min;
            for (int i = 0; i < tableau.Length - 1; i++)
            {
                min = i;

                // Identifier la plus petite valeur
                for (int j = i + 1; j < tableau.Length; j++)
                {
                    nbTriSelection++;
                    if(tableau[j] < tableau[min]){
                        min = j;
                    }
                }

                // Si on a trouvé plus petit que la première valeur, on 
                // échange
                nbTriSelection++;
                if(min != i){
                    nbTriSelection++;
                    echanger(ref tableau[i], ref tableau[min]);
                }
            }
        }
    }
}
