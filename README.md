# PromocyjnePrzepisy
## Aplikacja mobilna rekomendująca przepisy kulinarne na podstawie aktualnych promocji w supermarketach.

## Repozytorium dotyczy aplikacji klienckiej

### Przykładowe funkcjonalności:
Przeglądanie dań z przecenionymi produktami (użytkownik widzi w liście nazwę dania, zdjęcie dania oraz ilość produktów w promocji zawartych w daniu).
Filtrowanie propozycji po rodzaju supermarketu, rodzaju produktu/ów czy preferencji żywieniowych(wegańskie, wegeteriańskie).
Generowanie listy zakupów na podstawie wybranego przepisu.
Podgląd dania wraz z przepisem oraz konkretnymi produktami w przecenie.
Dodawanie cen zakupionych produktów na podstawie skanu paragonu lub ręcznym wprowadzeniu ceny (działanie nieobowiązkowe dla użytkownika, ale ułatwiające określanie całkowitej ceny dania dla innych użytkowników).

### Podstawowy cel stworzenia aplikacji:
Ułatwienie wyboru zakupów konkretnych produktów spożywczych, które są najkorzystniejsze cenowo w danym czasie (pobudki ekonomiczne)

### Architektura aplikacji (mikroserwisy):
* Aplikacja kliencka - .Net MAUI (Multiplatform App UI) na Androida i iOS z wykorzystaniem wzorca MVVM.
* Mikroserwis OCR - Tesseract-ocr (open source) dla .net + Openai API do przetwarzania tekstu i deserializacji w obiekty klas (JSON -> Obiekt -> Encja w bazie danych) + serwis pobierający gazetki w formacie pdf ze stron supermarketów.
* Baza danych MySQL dla przechowywania encji przetworzonych obiektów z OCR.
* Baza danych MySQL dla przechowywania przepisów kulinarnych .
* Mikroserwis do przetwarzania propozycji zakupowych (logika biznesowa) na podstawie informacji wyciągniętych z bazy danych.
* Baza danych MySQL dla przechowywania gotowych propozycji zakupowych dla głównej strony aplikacji.
* ASP .NET web API do komunikacji między serwisami.
Inne nieokreślone przez brak doświadczenia/wiedzy/wyobraźni - w tej chwili nie uwzględniam na przykład tworzenia użytkowników w aplikacji.
