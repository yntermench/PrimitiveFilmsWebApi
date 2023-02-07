using PrimitiveFilmsWebApi;
using System.Text.RegularExpressions;

List<Film> films = new List<Film>()
{
    new () {
        Id = Guid.NewGuid().ToString(),
        Title = "������� �� �����",
        Description = "������ ��������� � ����� �������� �����. ���� �������� ������� ������� � ��������� �������, �� ��� ������� � ������ ��������" +
        " � �������� �����������, ������� �������� ������ ������� � ����������� ������ ��������, �� �� �� ���� ���� ������������ �����������." +
        " ��� ��� �������� ����������� ���� ���������� ����� �����, � ����� ��-�������� �������� �������������, � ����� ������ ������� ������������.",
        Genre = "�����"
    },

    new () {
        Id = Guid.NewGuid().ToString(),
        Title = "������� �� �����",
        Description = "������ ��������� � ����� �������� �����. ���� �������� ������� ������� � ��������� �������, �� ��� ������� � ������ ��������" +
        " � �������� �����������, ������� �������� ������ ������� � ����������� ������ ��������, �� �� �� ���� ���� ������������ �����������." +
        " ��� ��� �������� ����������� ���� ���������� ����� �����, � ����� ��-�������� �������� �������������, � ����� ������ ������� ������������.",
        Genre = "�����"
    },

    new () {
        Id = Guid.NewGuid().ToString(),
        Title = "������� �� �����",
        Description = "������ ��������� � ����� �������� �����. ���� �������� ������� ������� � ��������� �������, �� ��� ������� � ������ ��������" +
        " � �������� �����������, ������� �������� ������ ������� � ����������� ������ ��������, �� �� �� ���� ���� ������������ �����������." +
        " ��� ��� �������� ����������� ���� ���������� ����� �����, � ����� ��-�������� �������� �������������, � ����� ������ ������� ������������.",
        Genre = "�����"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    string regularExpressions = @"^/api/films/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

    if (path == "/api/films" && request.Method == "GET")
    {
        await WebFilmService.GetAllFilms(response, films);
    }
    else if(Regex.IsMatch(path, regularExpressions) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await WebFilmService.GetFilm(id, response, films);
    }
    else if(path == "/api/films" && request.Method == "POST")
    {
        await WebFilmService.CreateFilm(response, request, films);
    }
    else if(path == "/api/films" && request.Method == "PUT")
    {
        await WebFilmService.EditFilm(response, request, films);
    }
    else if(Regex.IsMatch(path, regularExpressions) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await WebFilmService.DeleteFilm(id, response, films);
    }
    else
    {
        response.ContentType = "text/html charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});
app.Run();
