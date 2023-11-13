using Blazored.FluentValidation;
using JNHAutos.Data;
using JNHAutos.Domain;
using JNHAutos.Domain.Validators;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace JNH_Autos.Pages
{
    public partial class Contact
    {
        [Inject]
        public IEmailRepository EmailRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        ContactViewModel ContactViewModel = new ContactViewModel();

        private FluentValidationValidator? _fluentValidationValidator;

        public async void FormSubmit()
        {
            if (await _fluentValidationValidator!.ValidateAsync())
            {
                await EmailRepository.SendContactEmail(ContactViewModel.Name, ContactViewModel.Email, ContactViewModel.PhoneNumber, ContactViewModel.Message);

                NavigationManager.NavigateTo("thank-you");
            }
        }
    }
}