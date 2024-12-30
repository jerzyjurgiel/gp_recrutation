Implementacja PoC Chatbot'a AI.

Aby uruchomić projekt należy
1. Odpalić docker compose up -d, w folderze aplikacji .NET, aby utworzyć i skonfigurować kontener z serwerem MSSQL.
2. Skompilować oraz uruchomić aplikację .NET (Dostępny Swagger) (migracje powinny wykonać się samodzielnie przy starcie)
3. W folderze ChatbotFrontend odpalić npm install oraz ng serve.

Opis projektu:
Aplikacja w bazie danych utrzymuje historię czatów i wiadomości z rozróżnieniem różnych chatów (brak wsparcia dla użytkowników).
Do komunikacji pomiędzy warstwą kontrolerów a logiką biznesową/bazodanową służy warstwa mediatora.
Serwis obsługujący "AI" oparty jest na interfejsie, dzięki czemu możliwa jest jego późniejsza podmiana na właściwą implementację.
Widok angularowy na froncie pokazuje historię czatu (id 1) do ewentualnej zmiany w kodzie (brak użytkowników).
Przy ustawieniu id czatu na null, przy wysłaniu pierwszej wiadomości, na front zwaracane jest id nowo założonej historii i wszystkie kolejne w niej wiadomości lądują w tym samym worku.
W tym przypadku przy każdym odświeżeniu resetowała by się historia czatu (ciągle nowy).

Po otrzymaniu wiadomości z backendu, tekst jest dzielony na części i wyświetlany stopniowo symulując człowieka piszącego słowa na klawiaturze.
W momencie anulowania odpowiedzi, proces jest zatrzymywany a do API wysyłana informacja o stanie w jakim wiadomość została przerwana.
Dla każdej wiadomości AI dostępna jest kontrolka "kciuk w góre" oraz "kciuk w dół", pozwalająca oceniać odpowiedź.
Ocena jest zapisywana przy wiadomości w bazie, możliwa do zmiany w każdej chwili.
