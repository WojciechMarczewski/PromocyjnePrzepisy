# Promocyjne Przepisy
## Aplikacja mobilna rekomendująca przepisy kulinarne na podstawie aktualnych promocji w supermarketach.

## Repozytorium dotyczy aplikacji klienckiej, która działa póki co jedynie na Androidzie.


## Środowisko deweloperskie:
Visual Studio 2022 Community Edition, Framework .Net MAUI (Muli-Platform App UI), GIT.

### Przykładowe funkcjonalności:
* Przeglądanie dań z przecenionymi produktami (użytkownik widzi w liście nazwę dania, zdjęcie dania oraz ilość produktów w promocji zawartych w daniu).
* Filtrowanie propozycji po rodzaju supermarketu, rodzaju produktu/ów czy preferencji żywieniowych(wegańskie, wegeteriańskie).
* Generowanie listy zakupów na podstawie wybranego przepisu.
* Podgląd dania wraz z przepisem oraz konkretnymi produktami w przecenie.
* Dodawanie cen zakupionych produktów na podstawie skanu paragonu lub ręcznym wprowadzeniu ceny (działanie nieobowiązkowe dla użytkownika, ale ułatwiające określanie całkowitej ceny dania dla innych użytkowników) - w tej chwili odłożona funkcjonalność.

### Podstawowy cel stworzenia aplikacji:
Ułatwienie wyboru zakupów konkretnych produktów spożywczych, które są najkorzystniejsze cenowo w danym czasie (pobudki ekonomiczne)

### Zasada działania:
Aplikacja pobiera dane o przepisach oraz o promocjach w supermarketach z serwera. W celu aktualizacji danych o promocjach, serwis Workera pobiera zdjęcia gazetek reklamowych ze stron supermarketów, a następnie przetwarza je za pomocą technologii OCR, w celu ekstrakcji informacji o promocjach. Aplikacja w zamyśle jest stworzona we wzorcu MVVM.










