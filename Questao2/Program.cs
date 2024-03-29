using Newtonsoft.Json;
using Questao2;
using System.Collections.Generic;

public class Program
{


    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string apiUrl = "https://jsonmock.hackerrank.com/api/football_matches";
        int totalGols = 0;
        int page = 1;

        while (true)
        {
            using (HttpClient client = new HttpClient())
            {
                string urlComParametros = $"{apiUrl}?year={year}&team1={team}&page={page}";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlComParametros).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Leia a resposta como uma string JSON
                        string json = response.Content.ReadAsStringAsync().Result;

                        // Faça o processamento do JSON aqui, como desserialização para um objeto C#
                        // Exemplo de desserialização usando Json.NET (Newtonsoft.Json)
                        dynamic data = JsonConvert.DeserializeObject(json);

                        foreach (var match in data.data)
                        {
                            // Somando os gols da equipe nos jogos
                            totalGols += Int32.Parse(match.team1goals.ToString());
                            //totalGols += Int32.Parse(match.team2goals.ToString());
                        }

                        int totalPaginas = int.Parse(data.total_pages.ToString());
                        if (page >= totalPaginas)
                        {
                            page = 1;
                            break;
                        }
                        else
                        {
                            page++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Falha na solicitação: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro na solicitação: {e.Message}");
                }

            }
        }

        

        while (true)
        {
            using (HttpClient client = new HttpClient())
            {
                string urlComParametros = $"{apiUrl}?year={year}&team2={team}&page={page}";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlComParametros).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Leia a resposta como uma string JSON
                        string json = response.Content.ReadAsStringAsync().Result;

                        // Faça o processamento do JSON aqui, como desserialização para um objeto C#
                        // Exemplo de desserialização usando Json.NET (Newtonsoft.Json)
                        dynamic data = JsonConvert.DeserializeObject(json);

                        foreach (var match in data.data)
                        {
                            // Somando os gols da equipe nos jogos
                            //totalGols += Int32.Parse(match.team1goals.ToString());
                            totalGols += Int32.Parse(match.team2goals.ToString());
                        }

                        int totalPaginas = int.Parse(data.total_pages.ToString());
                        if (page >= totalPaginas)
                        {
                            page = 1;
                            break;
                        }
                        else
                        {
                            page++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Falha na solicitação: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro na solicitação: {e.Message}");
                }

            }
        }

        return totalGols;
    }
}