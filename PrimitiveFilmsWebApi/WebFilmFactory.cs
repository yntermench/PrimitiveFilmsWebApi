namespace PrimitiveFilmsWebApi
{
    /// <summary>
    /// Stores responses to web-requests of the class <see cref="Film"></see>.
    /// </summary>
    static public class WebFilmService
    {
        /// <summary>
        /// Sends all films as json to the response body.
        /// </summary>
        /// <returns>The <see cref="HttpResponse"></see> about all films.</returns>
        static public async Task GetAllFilms(HttpResponse response, List<Film> films)
        {
            await response.WriteAsJsonAsync(films);
        }
        /// <summary>
        /// Sends by id film as json to the response body.
        /// </summary>
        /// <returns>The <see cref="HttpResponse"></see> about selecting <see cref="Film">film</see>.</returns>
        static public async Task GetFilm(string? id, HttpResponse response, List<Film> films)
        {
            Film? film = films.FirstOrDefault((u) => u.Id == id);
            if (film != null)
            {
                await response.WriteAsJsonAsync(film);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Фильм не найден" });
            }
        }
        /// <summary>
        /// Creates new film and sends creating film as json to the response body.
        /// </summary>
        /// <returns>The <see cref="HttpResponse"></see> about creating <see cref="Film">film</see>.</returns>
        static public async Task CreateFilm(HttpResponse response, HttpRequest request, List<Film> films)
        {
            try
            {
                Film? film = await request.ReadFromJsonAsync<Film>();
                if (film != null)
                {
                    film.Id = Guid.NewGuid().ToString();
                    films.Add(film);
                    await response.WriteAsJsonAsync(film);
                }
                else
                {
                    throw new Exception("Неккоректные данные");
                }
            }
            catch (Exception)
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { message = "Неккоректные данные" });
            }
        }
        /// <summary>
        /// Edits selecting film and sends editing films as json to the response body.
        /// </summary>
        /// <returns>The <see cref="HttpResponse"></see> about editing <see cref="Film">film</see>.</returns>
        static public async Task EditFilm(HttpResponse response, HttpRequest request, List<Film> films)
        {
            try
            {
                Film? filmData = await request.ReadFromJsonAsync<Film>();
                if (filmData != null)
                {
                    Film? film = films.FirstOrDefault((f) => f.Id == filmData.Id);
                    if (film != null)
                    {
                        film.Title = filmData.Title;
                        film.Genre = filmData.Genre;
                        film.Description = filmData.Description;
                        await response.WriteAsJsonAsync(film);
                    }
                    else
                    {
                        response.StatusCode = 404;
                        await response.WriteAsJsonAsync(new { message = "Фильм не найден" });
                    }
                }
                else
                {
                    throw new Exception("Неккоректные данные");
                }
            }
            catch (Exception)
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { message = "Неккоректные данные" });
            }
        }
        /// <summary>
        /// Removes film by id and sends removing film as json to the response body.
        /// </summary>
        /// <returns>The <see cref="HttpResponse"></see> about removing <see cref="Film">film</see>.</returns>
        static public async Task DeleteFilm(string? id, HttpResponse response, List<Film> films)
        {
            Film? film = films.FirstOrDefault(f => f.Id == id);
            if (film != null)
            {
                films.Remove(film);
                await response.WriteAsJsonAsync(film);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Фильма не найден" });
            }
        }
    }
}
