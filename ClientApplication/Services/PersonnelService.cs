using ClientApplication.Services.HttpClientService;
using ClientApplication.Models;
using System.Net;

namespace ClientApplication.Services.PersonnelService;

public class PersonnelService{
    public static async Task<Personnels> getPersonnels(){
        var personnels = await HttpClientService.HttpClientService.GetAsync<Personnels>("Personnel");
        if(personnels is null) return new Personnels();
        return personnels;
    }
    public static async Task<string> createPersonnel(Personnel personnel)
    {
        var u = await HttpClientService.HttpClientService.PostAsync<Personnel>("Personnel", personnel);
        return u.ToString().Split('/').Last();
    }
    public static async Task<HttpStatusCode> updatePersonnel(int id, Personnel personnel){
        return await HttpClientService.HttpClientService.PutAsync<Personnel>($"Debit/{id}", personnel);
    }
    public static async Task<HttpStatusCode> deletePersonnel(int id){
        return await HttpClientService.HttpClientService.DeleteAsync($"Personnel/{id}");
    }

}
