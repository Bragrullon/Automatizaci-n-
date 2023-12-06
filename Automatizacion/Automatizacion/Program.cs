using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using OpenQA.Selenium.Support.UI;

namespace Automatizacion
{
    class Program
    {


        public class LoginAuto : IDisposable
        {
            private IWebDriver _driver;

            public LoginAuto()
            {
                //Esto es la conexión para Google
                _driver = new ChromeDriver();
            }

            public void IniciarSesionAceptado()
            {
                // Encontrar la página de inicio de sesión
                _driver.Navigate().GoToUrl("https://accounts.spotify.com/en/login?continue=https%3A%2F%2Fopen.spotify.com%2F");
                
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Encontrar el campo de usuario y contraseña
                IWebElement usernameField = _driver.FindElement(By.Id("login-username"));
                usernameField.SendKeys("bragrullon");
                
                IWebElement passwordField = _driver.FindElement(By.Id("login-password"));
                passwordField.SendKeys("Huracan75");
                
                System.Threading.Thread.Sleep(1000); // Esto es para esperar
                IWebElement loginButton = _driver.FindElement(By.Id("login-button"));
                loginButton.Click();

                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => !driver.Url.Contains("login"));


                Assert.Contains("https://open.spotify.com/", _driver.Url);
            }

            

            public void Dispose()
            {
                _driver.Quit();
            }
        }

  
            static void Main(string[] args)
            {
                LoginAuto login = new LoginAuto();
                login.IniciarSesionAceptado();
                //login.Dispose();
                
            }
        }
    }


 



    



