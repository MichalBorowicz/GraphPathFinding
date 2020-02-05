# GraphPathFinding

Projekt z przedmiotu Roboty Mobilne
https://eti.pg.edu.pl/katedra-systemow-automatyki/strona-glowna
Wstęp:
Struktura projektu została podzielona na 6 katalogów:
-Abstract - folder ten zawiera abstrakcję, która opisuje implementację z folderu Algorithms

-Algorithms - folder ten zawiera implementację algorytmów A*, Dijkstry, PRM, Composition oraz Raster method.

-Helpers - Folder ten zawiera pomocnicze klasy wykorzystywane w różnych miejscach projektu. Folder składa się z dwóch podfolderów
  -Abstract - folder zawiera wszystkie twory abstrakcyjne folderu nadrzędnego, w  tym przypadku są to interfejsy
  -Implementation - folder zawiera wszystkie składowe implementacji funkcjonalności opisane przez folder nadrzędny, w tym wypadku jest to klasa "ConvertBitmapToSourceImageHelper", której zadaniem jest konwersja typu bitmap na sourceImage
  
-Installers - w folderze tym znajduje się konfiguracja Castle Windsdor, czyli kontener IoC dzięki któremu można w aplikacji korzystać z Dependency Injection

-Models - w tym katalogu przechowywane są wszystkie modele, które są użyte w aplikacji

-Resources - w tym katalogu znajdują się dodatkowe zasoby jak między innymi zdjęcie mapy świata


Opis klas z folderu Algorithms:
-AStarAlgorithm - docelowa klasa powinna zawierać implementację A*, na moment obecny przy wywołaniu rzuci wyjątkiem

-DijkstraAlgorithm - klasa zawierająca implementację algorytmu dijkstry. Na zewnątrz jest wystawiona jedna metoda:
    -Get - metoda wywołująca algorytm i zaznaczająca ścieżkę na mapie, na wejściu przyjmuje bitmapę oraz kolekcję punktów będących         wierzchołkami grafu
-PRM - klasa zawierająca implementację PRM. Na zewnątrz wystawione są dwie metody:
      -GetPoints - metoda, która zwraca punkty wygenerowane przez klasę PRM
      -Get - metoda, która wykonuje algorytm PRM oraz rysuje wytypowane punkty na bitmapie, na wejściu przyjmuje ścieżkę do bitmapy, a na wyjściu zwraca bitmapę, z naniesionymi punktami
      
-Composition - klasa powinna zawierać implementację algorytmu, jednakże na chwilę obecną zwraca wyjątek

-RasterAlgorithm - klasa zawierająca implementację algorytmu rastrowego, na wejściu metody "Get" przyjmuje ścieżkę do pliku, a na wyjściu zwracana jest bitmapa z naniesionymi punktami znalezionymi przez algorytm, kropki oznaczają wierzchołki, a czerwone kwadraty sposób w jaki zostały wyznaczone wierzchołki. Metoda GetPoints zwraca kolekcję punktów wygenerowanych przez algorytm. 
