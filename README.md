# Promocyjne Przepisy
## Aplikacja mobilna rekomendująca przepisy kulinarne na podstawie aktualnych promocji w supermarketach.

## Repozytorium dotyczy aplikacji klienckiej, która będzie działać jedynie na Androidzie (nie mam urządzeń z system iOS do testowania aplikacji).

> [!NOTE]
> Link do mockupu w figmie (pierwsze podejście ukończone): [LINK](https://www.figma.com/proto/tv9aa3ogYHgB75HspjybIR/PromocyjnePrzepisy?type=design&node-id=15-854&t=vu8W7AjkR3wcEZRC-1&scaling=contain&page-id=0%3A1)
> 
> Jestem otwarty na sugestie, krytykę itp.

> [!NOTE]
> Projekt Jiry do zarządzania projektem: [LINK](https://id.atlassian.com/invite/p/jira-software?id=W-agM5jUQsSYHxT5gt3NzQ)

Link do dziennika praktyk: [LINK](https://docs.google.com/document/d/1WVQkgTRC11jlCx_qyGrfYsIaDCmFzqLI/edit?usp=sharing&ouid=102039872799773985673&rtpof=true&sd=true)

## Środowisko deweloperskie:
Visual Studio 2022 Community Edition, Framework .Net MAUI (Muli-platform app UI), Projekt testów jednostkowych xUnit, GIT.

### Przykładowe funkcjonalności:
* Przeglądanie dań z przecenionymi produktami (użytkownik widzi w liście nazwę dania, zdjęcie dania oraz ilość produktów w promocji zawartych w daniu).
* Filtrowanie propozycji po rodzaju supermarketu, rodzaju produktu/ów czy preferencji żywieniowych(wegańskie, wegeteriańskie).
* Generowanie listy zakupów na podstawie wybranego przepisu.
* Podgląd dania wraz z przepisem oraz konkretnymi produktami w przecenie.
* Dodawanie cen zakupionych produktów na podstawie skanu paragonu lub ręcznym wprowadzeniu ceny (działanie nieobowiązkowe dla użytkownika, ale ułatwiające określanie całkowitej ceny dania dla innych użytkowników) - w tej chwili odłożona funkcjonalność.

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
* Inne nieokreślone przez brak doświadczenia/wiedzy/wyobraźni - w tej chwili nie uwzględniam na przykład tworzenia użytkowników w aplikacji.

## Najbliższe działania:
1. Implementacja Modeli i ViewModeli w tym binding ViewModel <-> View

## Wykonane:
* Przygotowanie środowiska pracy - stworzenie projektu aplikacji w Visual Studio
* Inicjalizacja repozytorium systemu kontroli wersji
* Stworzenie prostego mockupu interfejsu użytkownika w figmie
* Implementacja widoków na podstawie mockupu.
* Stworzenie historyjek użytkownika - jasne określenie jakie funkcjonalności będzie zawierała aplikacja 

# Plan godzinowy na kwiecień (80 godzin)
Dzień - Czas trwania - Przedział godzinowy
* 16.04.2024 - 8h - 10:00 - 18:00;
* 17.04.2024 - 8h - 10:00 - 18:00;
* 18.04.2024 - 4h - 20:30 - 00:30;
* 19.04.2024 - 4h - 20:30 - 00:30;
* 20.04.2024 - 6h - 18:00 - 00:00;
* 21.04.2024 - 6h - 18:00 - 00:00;
* 22.04.2024 - 4h - 20:30 - 00:30;
* 23.04.2024 - 4h - 20:30 - 00:30;
* 24.04.2024 - 4h - 20:30 - 00:30;
* 25.04.2024 - 4h - 20:30 - 00:30; (wolne)
* 26.04.2024 - 4h - 20:30 - 00:30; (wolne)
* 27.04.2024 - 8h - 10:00 - 18:00;
* 28.04.2024 - 8h - 10:00 - 18:00;
* 29.04.2024 - 8h - 10:00 - 18:00;
* 30.04.2024 - 8h - 10:00 - 18:00;

Notatka: W dniach 16.04 i 17.04 jest zapisane 16h w ramach zapoznawania się z przedsiębiorstwem (zobacz Dziennik Praktyk), więc odejmując to od zaplanowanych godzin zostaje 64h. W planie sumarycznie jest 72h, więc 8h godzin jest nadmiarowe - prawdopodobnie 2 dni po 4h będą odjęte, albo zredukuje się czas 4 godzinnych aktywności do 3 godzin. Dni z 8 godzinami to dni wolne od pracy, weekend 6h jest dniem zjazdowym na uczelni.

# Plan godzinowy na maj (120 godzin)
Dzień - Czas trwania - Przedział godzinowy
* 02.05.2024 - 8h - 10:00 - 18:00
* 04.05.2024 - 8h - 10:00 - 18:00
* 05.05.2024 - 8h - 10:00 - 18:00
* 06.05.2024 - 4h - 20:30 - 00:30
* 07.05.2024 - 4h - 20:30 - 00:30
* 09.05.2024 - 4h - 20:30 - 00:30
* 11.05.2024 - 6h - 20:30 - 02:30
* 12.05.2024 - 6h - 20:30 - 02:30
* 13.05.2024 - 4h - 20:30 - 00:30
* 14.05.2024 - 4h - 20:30 - 00:30
* 16.05.2024 - 4h - 20:30 - 00:30
* 18.05.2024 - 8h - 10:00 - 18:00
* 19.05.2024 - 8h - 10:00 - 18:00
* 20.05.2024 - 4h - 20:30 - 00:30
* 21.05.2024 - 4h - 20:30 - 00:30
* 23.05.2024 - 4h - 20:30 - 00:30
* 24.05.2024 - 4h - 20:30 - 00:30
* 25.05.2024 - 6h - 20:30 - 02:30
* 26.05.2024 - 6h - 20:30 - 02:30
* 27.05.2024 - 4h - 20:30 - 00:30
* 28.05.2024 - 4h - 20:30 - 00:30
* 29.05.2024 - 4h - 20:30 - 00:30
* 31.05.2024 - 4h - 20:30 - 00:30
  

# Plan godzinowy na czerwiec (80 godzin)
Dzień - Czas trwania - Przedział godzinowy
* 01.06.2024 - 6h - 10:00 - 16:00
* 02.06.2024 - 6h - 10:00 - 16:00
* 03.06.2024 - 4h - 20:30 - 00:30
* 05.06.2024 - 4h - 20:30 - 00:30
* 07.06.2024 - 4h - 20:30 - 00:30
* 08.06.2024 - 4h - 20:00 - 24:00
* 09.06.2024 - 4h - 20:00 - 24:00
* 10.06.2024 - 4h - 20:30 - 00:30
* 12.06.2024 - 4h - 20:30 - 00:30
* 14.06.2024 - 4h - 20:30 - 00:30
* 15.06.2024 - 5h - 10:00 - 15:00
* 16.06.2024 - 5h - 10:00 - 15:00
* 17.06.2024 - 4h - 20:30 - 00:30
* 19.06.2024 - 4h - 20:30 - 00:30
* 21.06.2024 - 4h - 20:30 - 00:30
* 22.06.2024 - 4h - 20:00 - 24:00
* 23.06.2024 - 4h - 20:00 - 24:00
* 24.06.2024 - 4h - 20:00 - 24:00
* 26.06.2024 - 4h - 20:30 - 00:30
* 28.06.2024 - 4h - 20:30 - 00:30
* 30.06.2024 - 4h - 20:30 - 00:30
