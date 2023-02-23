Aplikacja ShootingRange to prosta aplikacja internetowa napisana w technologii ASP.NET 6 MVC.
Jest to aplikacja dla firmy, która umożliwa klientom korzystanie ze strzelnicy.

Wymagania:
Do uruchomienia aplikacji potrzebujesz zainstalowanej wersji .NET 6 oraz bazy danych.

Instalacja i konfiguracja:

Sklonuj repozytorium aplikacji na swój komputer.
Utwórz nową bazę danych.
Otwórz projekt w Visual Studio 2022 lub innym edytorze.
Otwórz plik appsettings.json i ustaw łańcuch połączenia z bazą danych zgodnie z danymi bazy danych, którą utworzyłeś w kroku 2.
Uruchom aplikację.

Użytkownicy testowi:
Do aplikacji zostały dodani użytkownicy testowi, którzy posiadają swoje hasła.

admin, email/login: "admin@admin", hasło: "admin"
user, email/login: "user@user", hasło: "user"

Opis działania aplikacji:
Po uruchomieniu aplikacji na stronie głównej wyświetla się przycisk do rezerwacji oraz menu z wyborem: Strony Głównej, Broni, Instruktorów, Producentów oraz Rezerwacji.
Są również przyciski do rejestracji i logowania, z których użytkownik powinien skorzystać w pierwszej kolejności. Jeśli użytkownik zaloguje się na konto admina to otrzymuje
możliwość dodania, edycji, usuwania i wyświetlenia szczegółow danych w formularzach:  Bronie, Instruktorzy, Producenci oraz Rezerwacje ( Zwykły użytkownik może tylko wyświetlić szczegóły
oraz dodać rezerwacje, po dodaniu rezerwacji zwykły użytkownik ma podgląd tylko do swoich rezerwacji, a admin do wszystkich.)