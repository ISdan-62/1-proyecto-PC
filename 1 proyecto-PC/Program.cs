int opcion = 0;
do
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    Console.Write("Elegir la opcion a realizar: ");
    opcion=int.Parse(Console.ReadLine());
    Console.WriteLine();
    switch (opcion)
    {
        case 1:
            {
                string tipoContenido;
                bool correctoTipoContenido;
                string resultadoTipoContenido;

                double duracionMinutos = 0;
                double resultadoDuracionMinutos = 0;

                string clasificacionEdad;
                string resultadoClasificacionEdad;

                int horaProgamada = 0;
                int resultadoHoraProgamada = 0;

                string nivelProduccion;
                string resultadoNivelProduccion;

                bool clasificacioYhorario = false;
                bool validacionNivelP = false;
                bool duraciónYcontenido = false;

                bool reultadosValidacionTecnica;

                string resultadoClasificacionImpacto;

                Console.WriteLine("Ingrese el tipo de contenido:  (Pelicula, Serie, Documental, Evento en vivo) ");
                tipoContenido = Console.ReadLine().ToLower();
                string evaluarTipoContenido(string tipoContenido)
                {
                    while (tipoContenido != "pelicula" && tipoContenido != "serie" && tipoContenido != "documental" && tipoContenido != "evento en vivo")
                    {
                        Console.WriteLine("Contenido inválido. Intente nuevamente:");
                        tipoContenido = Console.ReadLine().ToLower ();
                    }
                    return tipoContenido;
                }
                resultadoTipoContenido = evaluarTipoContenido(tipoContenido);

                Console.WriteLine("Ingrese la duracion en minutos: (0-240) ");
                duracionMinutos=double.Parse(Console.ReadLine());
                double evaluarDuracionMinutos(double duracionMinutos)
                {
                    while (duracionMinutos <= 0 || duracionMinutos >= 240)
                    {
                        Console.WriteLine("Duración inválida. Intente nuevamente:");
                        duracionMinutos = double.Parse(Console.ReadLine());
                    }
                    return duracionMinutos;
                }
                resultadoDuracionMinutos=evaluarDuracionMinutos(duracionMinutos);

                Console.WriteLine("Ingrese la clasificación por edad: (todo público, +13, +18) ");
                clasificacionEdad = Console.ReadLine();
                string evaluarClasificacionEdad(string clasificacionEdad)
                {
                    while (clasificacionEdad!="Todo publico" && clasificacionEdad!="+13" && clasificacionEdad!="+18")
                    {
                        Console.WriteLine("Clasificacion inválida. Intente nuevamente:");
                        clasificacionEdad = Console.ReadLine();
                    }
                    return clasificacionEdad;
                }
                resultadoClasificacionEdad = evaluarClasificacionEdad(clasificacionEdad);

                Console.WriteLine("Ingrese la hora programa: (0-23) ");
                horaProgamada = int.Parse(Console.ReadLine());
                int evaluarHoraProgamada(int horaProgamada)
                {
                    while (horaProgamada <= 0 || duracionMinutos >= 23)
                    {
                        Console.WriteLine("Hora rogamada inválida. Intente nuevamente:");
                        horaProgamada = int.Parse(Console.ReadLine());
                    }
                    return horaProgamada;
                }
                resultadoHoraProgamada = evaluarHoraProgamada(horaProgamada);

                Console.WriteLine("Ingrese la clasificación por edad: (Bajo, Medio, Alto) ");
                nivelProduccion = Console.ReadLine().ToLower();
                string evaluarNivelProduccion(string nivelProduccion)
                {
                    while (nivelProduccion != "Bajo" && nivelProduccion != "Medio" && nivelProduccion != "Alto")
                    {
                        Console.WriteLine("Clasificacion inválida. Intente nuevamente:");
                        nivelProduccion = Console.ReadLine();
                    }
                    return nivelProduccion;
                }
                resultadoNivelProduccion = evaluarNivelProduccion(nivelProduccion);

                bool validacionTecnica(bool clasificacioYhorario, bool validacionNivelP, bool duraciónYcontenido)
                {
                    if (resultadoClasificacionEdad == "Todo publico")
                    {
                        if (resultadoHoraProgamada >= 0 && resultadoHoraProgamada <= 23)
                        {
                            clasificacioYhorario = true;
                        }

                    }
                    else if (resultadoClasificacionEdad == "+13")
                    {
                        if (resultadoHoraProgamada >= 6 && resultadoHoraProgamada <= 22)
                        {
                            clasificacioYhorario = true;
                        }
                    }
                    else if (resultadoClasificacionEdad == "+18")
                    {
                        if (resultadoHoraProgamada >= 22 && resultadoHoraProgamada <= 5)
                        {
                            clasificacioYhorario = true;
                        }
                    }
                    else
                    {
                        clasificacioYhorario = false;
                    }

                    if (resultadoTipoContenido == "Pelicula")
                    {
                        if (resultadoDuracionMinutos >= 60 && resultadoDuracionMinutos <= 180)
                        {
                            duraciónYcontenido = true;
                        }
                    }
                    else if (resultadoTipoContenido == "Serie")
                    {
                        if (resultadoDuracionMinutos >= 20 && resultadoDuracionMinutos <= 90)
                        {
                            duraciónYcontenido = true;
                        }
                    }
                    else if (resultadoTipoContenido == "Documental")
                    {
                        if (resultadoDuracionMinutos >= 30 && resultadoDuracionMinutos <= 120)
                        {
                            duraciónYcontenido = true;
                        }
                    }
                    else if (resultadoTipoContenido == "Evento en vivo")
                    {
                        if (resultadoDuracionMinutos >= 30 && resultadoDuracionMinutos <= 240)
                        {
                            duraciónYcontenido = true;
                        }
                    }
                    else
                    {
                        duraciónYcontenido = false;
                    }

                    if (resultadoNivelProduccion == "Bajo")
                    {
                        if (resultadoClasificacionEdad == "Todo publico")
                        {
                            validacionNivelP = true;
                        }
                    }
                    else if (resultadoNivelProduccion == "Medio" || resultadoNivelProduccion == "Alto")
                    {
                        if (resultadoClasificacionEdad == "+13" && resultadoClasificacionEdad == "+18")
                        {
                            validacionNivelP = true;
                        }
                    }
                    else
                    {
                        validacionNivelP = false;
                    }

                    return duraciónYcontenido && clasificacioYhorario && validacionNivelP;
                }
                reultadosValidacionTecnica = validacionTecnica(clasificacioYhorario, validacionNivelP, duraciónYcontenido);

                bool impactoAlto = resultadoNivelProduccion == "Alto" || resultadoDuracionMinutos > 120 || (resultadoHoraProgamada >= 20 && resultadoHoraProgamada <= 23);
                bool impactoMedio = resultadoNivelProduccion == "Medio" || (resultadoDuracionMinutos >= 60 && resultadoDuracionMinutos <= 120);
                bool impactoBajo = resultadoNivelProduccion == "Bajo" && resultadoDuracionMinutos < 60;
                string clasificacionImpacto(bool impactoAlto, bool impactoMedio, bool impactoBajo)
                {
                    if (clasificacioYhorario && duraciónYcontenido && validacionNivelP)
                    {
                        if (impactoAlto)
                        {
                            return "Impacto Alto";
                        }
                        else if (impactoMedio)
                        {
                            return "Impacto Medio";
                        }
                        else if (impactoBajo)
                        {
                            return "Bajo";
                        }
                    }
                    return "No válido";
                }
                resultadoClasificacionImpacto = clasificacionImpacto(impactoAlto, impactoMedio, impactoBajo);



                break;
            }
        case 2:
            {
                break;
            }
        case 3:
            {
                break;
            }
        case 4:
            {
                break;
            }
        case 5:
            {
                Console.WriteLine("Salida");
                break;
            }
        default:
            {
                Console.WriteLine("Opcion Invalida");
                break;
            }
    }
} while (opcion != 5);