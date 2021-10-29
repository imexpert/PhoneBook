FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/PhoneBook.Core/*.csproj Shared/PhoneBook.Core/
COPY Libraries/Book/PhoneBook.Libraries.Book.Api/*.csproj Libraries/Book/PhoneBook.Libraries.Book.Api/
RUN dotner restore Libraries/Book/PhoneBook.Libraries.Book.Api/*.csproj
COPY . .
RUN dotnet publish Libraries/Book/PhoneBook.Libraries.Book.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","PhoneBook.Libraries.Book.Api.dll"]