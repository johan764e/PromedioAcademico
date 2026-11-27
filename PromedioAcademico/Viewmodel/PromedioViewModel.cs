using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PromedioAcademico.Models;

namespace PromedioAcademico.ViewModels;

public class PromedioViewModel : INotifyPropertyChanged
{
       
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? n = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    string _cal1 = "", _cal2 = "", _cal3 = "";
        string _Promedio = "", _Nivel = "", _Mensaje = "";

        public string Cal1
        {
            get => _cal1;
            set
            {
                if (_cal1 != value)
                {
                    _cal1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Cal2
        {
            get => _cal2;
            set
            {
                if (_cal2 != value)
                {
                    _cal2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Cal3
        {
            get => _cal3;
            set
            {
                if (_cal3 != value)
                {
                    _cal3 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Promedio
        {
            get => _Promedio;
            set
            {
                if (_Promedio != value)
                {
                    _Promedio = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Nivel
        {
            get => _Nivel;
            set
            {
                if (_Nivel != value)
                {
                    _Nivel = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mensaje
        {
            get => _Mensaje;
            set
            {
                if (_Mensaje != value)
                {
                    _Mensaje = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CalcularCommand { get; }

        public PromedioViewModel()
        {
            CalcularCommand = new Command(Calcular);
        }

    private void Calcular()
    {
        Promedio = "";
        Nivel = "";
        Mensaje = "";

        if (!double.TryParse(Cal1, out double cal1) ||
            !double.TryParse(Cal2, out double cal2) ||
            !double.TryParse(Cal3, out double cal3))
        {
            Mensaje = "Por favor, ingresa valores numéricos válidos.";
            return;
        }

        if (cal1 < 0 || cal1 > 10 || cal2 < 0 || cal2 > 10 || cal3 < 0 || cal3 > 10)
        {
            Mensaje = "Por favor, ingresa valores entre 0 y 10.";
            return;
        }

        var calificaciones = new Calificaciones
        {
            Cal1 = cal1,
            Cal2 = cal2,
            Cal3 = cal3
        };

        double promedio = calificaciones.Promedio();

        Promedio = "Promedio: " + promedio.ToString("F2");

        if (promedio < 7)
        {
            Nivel = "Nivel: No acreditado";
        }
        else if (promedio < 8)
        {
            Nivel = "Nivel: Suficiente";
        }
        else if (promedio < 9)
        {
            Nivel = "Nivel: Bueno";
        }
        else
        {
            Nivel = "Nivel: Excelente";
        }
    }


}
