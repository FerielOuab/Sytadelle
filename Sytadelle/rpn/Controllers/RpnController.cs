using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using rpn.Models;


namespace rpn.Controllers
{
    [Route("api/rpn")] // Lien racine pour les requêtes HTTP ci-dessous
    public class RpnController: Controller{

        // Instanciation du modèle RPN afin de pouvoir utiliser communément la pile Numbers
        private static Rpn Pile = new Rpn{Numbers = new Stack<float>()};


        // Requête HTTP POST pour remplir la pile
        [HttpPost]
        // [Route("add/{number}")]
        [Route("add")]
        public Stack<float> FillStack(float number)
        {
            //la fonction prend un float en paramètre qui s'ajoutera à la pile en LIFO
            Pile.Numbers.Push(number);
            return Pile.Numbers;
        }

        
        // Requête HTTP GET pour retourner la pile
        [HttpGet]
        [Route("stack")]
        public Stack<float> GetStack()
        {
            return Pile.Numbers;
        }


        // Requête HTTP DELETE pour vider la pile
        [HttpDelete]
        [Route("delete")]
        public void DeleteStack()
        {
            // Si la pile n'est pas vide, la vider. Sinon, ne rien faire
            if (Pile.Numbers.Count != 0)
            {
                Pile.Numbers.Clear();
            }
        }


        // Requête HTTP GET pour additionner les deux derniers nombres de la pile
        [HttpGet]
        [Route("sum")]
        public Stack<float> SumNumbers()
        {
            // Si la pile contient au moins 2 élements, faire la somme. Sinon, afficher la pile
            if(Pile.Numbers.Count >= 2)
            {
                float somme = 0;
                somme += Pile.Numbers.Peek(); // Attribuer à la variable somme, la dernière valeur de la pile
                Pile.Numbers.Pop(); // Supprimer la dernière valeur de la pile
                somme += Pile.Numbers.Peek(); // Ajouter à la variable somme , la nouvelle dernière valeur de la pile
                Pile.Numbers.Pop();
                Pile.Numbers.Push(somme); // Ajouter la valeur somme à la pile
                return Pile.Numbers;
            }
            else
            {
                return Pile.Numbers;
            }
        }


        // Requête HTTP GET pour soustraire les deux derniers nombres de la pile
        [HttpGet]
        [Route("substract")]
        public Stack<float> SubstractNumbers()
        {
            if(Pile.Numbers.Count >= 2)
            {
                float somme = 0;
                somme += Pile.Numbers.Peek();
                Pile.Numbers.Pop();
                somme -= Pile.Numbers.Peek(); // Soustraire de la variable somme , la nouvelle dernière valeur de la pile
                Pile.Numbers.Pop();
                Pile.Numbers.Push(somme);
                return Pile.Numbers;
            }
            else
            {
                return Pile.Numbers;
            }
        }


        // Requête HTTP GET pour multiplier les deux derniers nombres de la pile
        [HttpGet]
        [Route("multiply")]
        public Stack<float> MultiplyNumbers()
        {
            if(Pile.Numbers.Count >= 2)
            {
                float somme = 1;
                somme *= Pile.Numbers.Peek();
                Pile.Numbers.Pop();
                somme *= Pile.Numbers.Peek(); // Multiplier la variable somme x la nouvelle dernière valeur de la pile
                Pile.Numbers.Pop();
                Pile.Numbers.Push(somme);
                return Pile.Numbers;
            }
            else
            {
                return Pile.Numbers;
            }
        }


        // Requête HTTP GET pour diviser les deux derniers nombres de la pile
        [HttpGet]
        [Route("divide")]
        public Stack<float> DivideNumbers()
        {
            if(Pile.Numbers.Count >= 2)
            {
                float somme = 0;
                somme = Pile.Numbers.Peek();
                Pile.Numbers.Pop();
                somme /= Pile.Numbers.Peek(); // Diviser la variable somme de la nouvelle dernière valeur de la pile
                Pile.Numbers.Pop();
                Pile.Numbers.Push(somme);
                return Pile.Numbers;
            }
            else
            {
                return Pile.Numbers;
            }
        }
    }
}