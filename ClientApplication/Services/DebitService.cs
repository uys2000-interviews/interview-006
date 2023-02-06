using ClientApplication.Services.HttpClientService;
using ClientApplication.Models;
using System.Net;

namespace ClientApplication.Services.DebitService;

public class DebitService{
    public static async Task<Debits> getDebits(){
        var debits = await HttpClientService.HttpClientService.GetAsync<Debits>("Debit");
        if(debits is null) return new Debits();
        return debits;
    }
    public static async Task<Debit?> createDebit(Debit debit)
    {
        return await HttpClientService.HttpClientService.PostAsync<Debit>("Debit", debit);
    }
    public static async Task<Debit?> getDebit(int id){
        var debit = await HttpClientService.HttpClientService.GetAsync<Debit>($"Debit/{id}");
        if (debit is null) return default;
        return debit;
    }
    public static async Task<Debit?> getDebitByFId(int fId){
        var debit = await HttpClientService.HttpClientService.GetAsync<Debit>($"Debit/fId/{fId}");
        if (debit is null) return default;
        return debit;
    }
    public static async Task<Debit?> getDebit(string fixtureId){
        var debit = await HttpClientService.HttpClientService.GetAsync<Debit>($"Debit/{fixtureId}");
        if (debit is null) return default;
        return debit;
    }
    public static async Task<HttpStatusCode> updateDebit(int id, Debit debit){
        return await HttpClientService.HttpClientService.PutAsync<Debit>($"Debit/{id}", debit);
    }
    public static async Task<HttpStatusCode> deleteDebit(int id){
        return await HttpClientService.HttpClientService.DeleteAsync($"Debit/{id}");
    }
    public static async Task<HttpStatusCode> deleteDebitByFId(int fId){
        return await HttpClientService.HttpClientService.DeleteAsync($"Debit/fId/{fId}");
    }
    public static async Task<HttpStatusCode> deleteDebitByFId(string fixtureId){
        return await HttpClientService.HttpClientService.DeleteAsync($"Debit/feId/{fixtureId}");
    }
    public static async Task<HttpStatusCode> deleteDebitByPId(int pId){
        return await HttpClientService.HttpClientService.DeleteAsync($"Debit/pId/{pId}");
    }
    public static async Task<HttpStatusCode> deleteDebitByPId(string personnelId){
        return await HttpClientService.HttpClientService.DeleteAsync($"Debit/peId/{personnelId}");
    }

}
