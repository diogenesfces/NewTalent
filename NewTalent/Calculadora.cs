using System;
using System.Collections.Generic;
using System.Text;

namespace NewTalent
{
    public class Calculadora
    {
        private List<string> listahistorico;
        private string data;

        public Calculadora(string data)
        {
            listahistorico = new List<string>();
            this.data = data;
        }
        public int Somar(int val1, int val2)
        {
            int res = val1 + val2;

            AddToHistorico($"Soma: {val1} + {val2} = {res}");
            return res;
        }

        public int Subtrair(int val1, int val2)
        {
            int res = val1 - val2;

            AddToHistorico($"Subtração: {val1} - {val2} = {res}");
            return res;
        }

        public int Multiplicar(int val1, int val2)
        {
            int res = val1 * val2;

            AddToHistorico($"Multiplicação: {val1} * {val2} = {res}");
            return res;
        }

        public int Dividir(int val1, int val2)
        {
            int res = val1 / val2;

            AddToHistorico($"Divisão: {val1} / {val2} = {res}");
            return res;
        }

        private void AddToHistorico(string operacao)
        {
            listahistorico.Insert(0, operacao);
            if (listahistorico.Count > 3)
            {
                listahistorico.RemoveAt(listahistorico.Count - 1);
            }
        }

        public List<string> historico()
        {
            return new List<string>(listahistorico);
        }


    }
}
