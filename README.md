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

## Wygląd aplikacji
### Strona Główna
<img src="https://github.com/user-attachments/assets/607ee869-5447-4fcc-ac7a-d57b3fb876fe" width="150" height="280">

### Podgląd przepisu
<img src="https://github.com/user-attachments/assets/4258c047-c26c-4dbe-85fb-fbc685f734ec" width="150" height="280">

### Menu Boczne
<img src="https://github.com/user-attachments/assets/84eef3c6-e5b7-48dd-a15e-028061bdf37a" width="150" height="280">

### Lista zakupów
<img src="https://github.com/user-attachments/assets/1a6f9855-845c-4d16-b2d5-d2caaa4f7f00" width="150" height="280">

### Wyszukiwarka produktów
<img src="https://github.com/user-attachments/assets/d6b6d3ec-2a35-4111-b6fd-45e0e1cc0ff8" width="150" height="280">

### Splashcreen
<img src="https://github.com/user-attachments/assets/eef158da-26cd-4ad6-806d-3d0b273ec5f4" width="150" height="280">

### Ikona

<img src="https://github.com/user-attachments/assets/77e670f7-f1cc-43b8-a23d-a7e51b3814ab">










