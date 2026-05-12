# PRZEWODNIK PO PROJEKCIE (DLA ZIELONKA) 🏋️‍♂️

Ten plik to Twoja "mapa", która tłumaczy jak działa Twój projekt Fitness Manager bez używania trudnego słownictwa.

---

## 📂 1. Gdzie co jest? (Struktura Folderów)

W Visual Studio patrzysz na **Solution Explorer**. Najważniejsze są te foldery:

1.  **`Models/` (DANE)**
    *   Tu są "przepisy" na to, co trzymamy w bazie.
    *   Każdy plik (np. `Member.cs`) to jedna tabela w bazie.
    *   **Tu szukaj relacji:** Jeśli chcesz sprawdzić, jak Klubowicz łączy się z Trenerem, wchodzisz w te pliki.

2.  **`Controllers/` (MÓZG)**
    *   Tu dzieje się cała akcja. Gdy klikasz przycisk na stronie, informacja leci do kontrolera.
    *   Kontroler mówi: "Bazo, daj mi tego klubowicza", a potem "Widoku, narysuj go na ekranie".
    *   **Tu szukaj logiki:** Jeśli chcesz zmienić co się dzieje po kliknięciu "Zapisz", szukasz tutaj.

3.  **`Views/` (WYGLĄD)**
    *   Tu są pliki `.cshtml`. Wyglądają jak HTML, ale pozwalają używać danych z C#.
    *   Są podzielone na podfoldery (np. `Views/Members/`), żebyś wiedział, który plik odpowiada za którą stronę.
    *   **Tu szukaj ekranów:** Jeśli chcesz zmienić napis na przycisku albo kolor tabeli, szukasz tutaj.

4.  **`Migrations/` (HISTORIA BAZY)**
    *   To są instrukcje dla bazy danych. Gdy zmieniamy coś w "przepisach" (Modelach), tworzymy migrację, żeby baza wiedziała, co ma u siebie przebudować.
    *   To taki "dziennik zmian" Twojej bazy.

5.  **`Properties/` (START)**
    *   Tu są techniczne ustawienia. Najważniejszy jest plik `launchSettings.json`, który mówi przeglądarce, pod jakim adresem (numerkiem portu) ma otworzyć Twoją aplikację.

6.  **`wwwroot/` (PLIKI STATYCZNE)**
    *   Tu trzymamy rzeczy "stałe": zdjęcia, ikonki i pliki CSS (style). To tutaj w folderze `css/site.css` zmienialiśmy kolory Twojej aplikacji na kremowe.

---

## 🔄 2. Jak to działa razem? (Trójkąt MVC)

Wyobraź sobie to jako restaurację:

1.  **KLIENT (Ty w przeglądarce):** Wybierasz danie z karty (klikasz link `/Members/Details/1`).
2.  **KELNER (Controller):** Przyjmuje zamówienie. Idzie do kuchni po składniki.
3.  **SKŁADNIKI (Model/Database):** Kontroler wyciąga dane z bazy.
4.  **KUCHARZ (View):** Kontroler podaje składniki kucharzowi. Kucharz układa je na talerzu (ładuje dane do HTML).
5.  **GOTOWE DANIE:** Ty dostajesz gotową stronę w przeglądarce.

---

## 🔗 3. Gdzie są te słynne relacje?

W Twoim projekcie masz dwie super-ważne rzeczy:

*   **Relacja Ukryta (Typ 1):** W pliku `Member.cs` zobaczysz `ICollection<GroupClass>`. To znaczy, że Klubowicz może chodzić na wiele zajęć. Nie widzisz "tabeli pomiędzy", bo Entity Framework robi ją sam w tle.
*   **Relacja z Payloadem (Typ 3):** To plik `TrainingSession.cs`. On łączy Klubowicza z Trenerem i **dopisuje coś ekstra** (Cenę i Datę). To jest ta tabela "pomiędzy", którą widzisz i możesz edytować.

---

## 🛠️ 4. Inne ważne pliki

*   **`Program.cs`:** Główny włącznik aplikacji. Tu konfigurujemy "usługi" (np. mówimy: "Używaj MySQL").
*   **`appsettings.json`:** Tu jest zapisany "ConnectionString", czyli adres i hasło do Twojej bazy danych w XAMPP.

**Teraz jak ktoś Cię zapyta o projekt, możesz śmiało powiedzieć: "Mamy czyste MVC z Eager Loadingiem relacji wiele-do-wielu podpięte pod MySQL przez EF Core". Brzmi jak profesjonalista! 😎**
