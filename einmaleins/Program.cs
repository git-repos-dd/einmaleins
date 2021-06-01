using System;

namespace einmaleins
{
    class Program
    {
        /*
         * \brief Funktion zur Ausgabe des Einmaleins auf der Konsole
         * 
         *      Die Funktion gibt das Einmaleins in der Größe des Parameters dimension aus. Je nach Stellenbedarf der Produkte wird die Textfarbe geändert
         *      max. Stellenbedarf = cyan
         *      max. Stellenbedarf - 1 = rot
         *      max. Stellenbedarf - 2 und kleiner = grün
         *      
         * \param dimension Dimension der Ausgabetabelle
         * \return int[dimension,dimension]
         * 
         */
        static public int[,] einmaleins(int dimension)
        {
            // 2-dimensionales Datenfeld mit der Dimension dimensionxdimension
            int[,] datenfeld = new int[dimension,dimension];

            // speichere Textfarbe
            ConsoleColor previous_color = Console.ForegroundColor;

            // maximale Anzahl von Stellen für ein einzelnes Produkt
            int max_ziffernstellen = Math.Pow(dimension, 2.0).ToString().Length;
            
            // Zeichenkette für eine Zeile
            // string zeile = "";

            // für alle Zeilen
            for (int i = 0; i < dimension; i++)
            {
                // für alle Spalten
                for (int j = 0; j < dimension; j++)
                {
                    // Produkt hat maximale Stellenanzahl?
                    if ((i + 1) * (j + 1) >= Math.Pow(10, max_ziffernstellen - 1))
                        
                        // setze Zeichenfarbe auf cyan
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    // Produkt hat maximale Stellenanzahl-1?
                    else if ((i + 1) * (j + 1) >= Math.Pow(10, max_ziffernstellen-2))
                    {
                        // setze Zeichenfarbe auf red
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    // Produkt hat kleinere Stellenanzahl als maximale Stellenanzahl -2?
                    else
                    {
                        // setze Zeichenfarbe auf green
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    // hänge an aktuelle Zeile das neue Produkt der Spalte an und formatiere es auf 4 Stellen
                    //zeile += String.Format("{0,"+(max_ziffernstellen+1).ToString()+"}", (j + 1) * (i + 1));
                    Console.Write(String.Format("{0," + (max_ziffernstellen + 1).ToString() + "}", (j + 1) * (i + 1)));

                    // speichere Produktterm im Datenfeld
                    datenfeld[j, i] = (j + 1) * (i + 1);
                }

                // Gebe die Zeile auf der Konsole aus
                // Console.WriteLine(zeile);
                Console.Write("\n");

                // Setze Zeichenkette zurück
                // zeile = "";
            }

            // setze Zeichenfarbe zurück 
            Console.ForegroundColor = previous_color;

            // gebe das Datenfeld zurück
            return datenfeld; 
        }

        static void Main(string[] args)
        {
            // gebe 5x5-Einmaleins-Tabelle aus
            einmaleins(5);

            // gebe 12x12-Einmaleins-Tabelle aus
            einmaleins(15);

            // gebe 34x34-Einmaleins-Tabelle aus
            einmaleins(34);

            // tabelle einmaleins als Rückgabe
            int[,] tab_einmaleins = einmaleins(34);
            
            // Produkt 33*12 ausgeben
            Console.WriteLine("Produkt: 33 * 12 = "+tab_einmaleins[32,11].ToString());
        }
    }
}
