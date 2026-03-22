int opcion = 0;
bool correcto;

double contadorTotalEvaluados = 0;
double contadorPublicados = 0;
int contadorRechazados = 0;
int contadorEnRevision = 0;

int contadorImpactoAlto = 0;
int contadorImppactoMedio = 0;
int contadorImpactoBajo = 0;

string ImpactoPredominante;

double porcentajeAprobacion;

do
{
    Console.WriteLine();
    Console.WriteLine("MENU");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    Console.Write("Elegir la opcion a realizar: ");
    correcto=int.TryParse(Console.ReadLine(), out opcion);
    Console.WriteLine();
    switch (opcion)
    {
        case 1:
            {
                string resultadoTipoContenido;
                double resultadoDuracionMinutos;
                string resultadoClasificacionEdad;
                int resultadoHoraProgamada;
                string resultadoNivelProduccion;

                bool resultadosValidacionTecnica;

                string resultadoClasificacionImpacto;

                string resultadoDecisionFinal;

                string evaluarTipoContenido()
                {
                    string tipoContenido;
                    while (true)
                    {
                        Console.WriteLine("Ingrese el tipo de contenido:  (Pelicula, Serie, Documental, Evento en vivo) ");
                        tipoContenido = Console.ReadLine().ToLower();
                        if (tipoContenido == "pelicula" || tipoContenido == "serie" || tipoContenido == "documental" || tipoContenido == "evento en vivo")
                        {
                            return tipoContenido;
                        }
                        else
                        {
                            Console.WriteLine("Contenido inválido...");
                            Console.WriteLine("Presione cualquier tecla para volver a intentar");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                resultadoTipoContenido = evaluarTipoContenido();

                double evaluarDuracionMinutos()
                {
                    double duracionMinutos;
                    bool correctoDminutos;
                    while (true)
                    {
                        Console.WriteLine("Ingrese la duracion en minutos: (0-240) ");
                        correctoDminutos = double.TryParse(Console.ReadLine(), out duracionMinutos);
                        if (correctoDminutos && duracionMinutos >= 0 && duracionMinutos <= 240)
                        {
                            return duracionMinutos;
                        }
                        else
                        {
                            Console.WriteLine("Duración inválida. Intente nuevamente:");
                            Console.WriteLine("Presione cualquier tecla para volver a intentar");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                resultadoDuracionMinutos=evaluarDuracionMinutos();

                string evaluarClasificacionEdad()
                {
                    int clasificacionEdad;
                    bool correctoCedad;
                    while (true)
                    {
                        Console.WriteLine("Ingrese la clasificación por edad: (mayor a 0 y menor a 120)");
                        correctoCedad = int.TryParse(Console.ReadLine(), out clasificacionEdad);
                        if (correctoCedad && clasificacionEdad > 0 &&clasificacionEdad<120)
                        {
                            if (clasificacionEdad>18)
                            {
                                return "+18";
                            }
                            else if (clasificacionEdad>13)
                            {
                                return "+13";
                            }
                            else
                            {
                                return "Todo publico";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Edad inválida. Intente nuevamente:");
                            Console.WriteLine("Presione cualquier tecla para volver a intentar");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                resultadoClasificacionEdad = evaluarClasificacionEdad();

                int evaluarHoraProgamada()
                {
                    int horaProgamada;
                    bool correctoHoraProgamada;
                    while (true)
                    {
                        Console.WriteLine("Ingrese la hora programa: (0-23) ");
                        correctoHoraProgamada=int.TryParse(Console.ReadLine(),out horaProgamada);
                        if (correctoHoraProgamada && horaProgamada>=0 && horaProgamada<=23)
                        {
                            return horaProgamada;
                        }
                        else
                        {
                            Console.WriteLine("Hora rogamada inválida. Intente nuevamente:");
                            Console.WriteLine("Presione cualquier tecla para volver a intentar");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                resultadoHoraProgamada = evaluarHoraProgamada();

                string evaluarNivelProduccion()
                {
                    string nivelProduccion;
                    while (true)
                    {
                        Console.WriteLine("Ingrese la clasificación por edad: (bajo, medio, alto) ");
                        nivelProduccion = Console.ReadLine().ToLower();
                        if (nivelProduccion == "bajo" || nivelProduccion == "medio"|| nivelProduccion=="alto")
                        {
                            return nivelProduccion;
                        }
                        else
                        {
                            Console.WriteLine("Clasificacion inválida. Intente nuevamente:");
                            Console.WriteLine("Presione cualquier tecla para volver a intentar");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                resultadoNivelProduccion = evaluarNivelProduccion();

                bool validacionTecnica()
                {
                    bool clasificacioYhorario;
                    bool validacionNivelP;
                    bool duraciónYcontenido;

                    if (resultadoClasificacionEdad == "Todo publico" &&resultadoHoraProgamada >= 0 && resultadoHoraProgamada <= 23)
                    {
                        clasificacioYhorario = true;
                    }
                    else if (resultadoClasificacionEdad == "+13"&&resultadoHoraProgamada >= 6 && resultadoHoraProgamada <= 22)
                    {
                        clasificacioYhorario = true;
                    }
                    else if (resultadoClasificacionEdad == "+18" && (resultadoHoraProgamada >= 22 || resultadoHoraProgamada <= 5))
                    {
                        clasificacioYhorario = true;
                    }
                    else
                    {
                        clasificacioYhorario = false;
                    }

                    if (resultadoTipoContenido == "pelicula"&& resultadoDuracionMinutos >= 60 && resultadoDuracionMinutos <= 180)
                    {
                        duraciónYcontenido = true;
                    }
                    else if (resultadoTipoContenido == "serie"&& resultadoDuracionMinutos >= 20 && resultadoDuracionMinutos <= 90)
                    {
                        duraciónYcontenido = true;
                    }
                    else if (resultadoTipoContenido == "documental"&& resultadoDuracionMinutos >= 30 && resultadoDuracionMinutos <= 120)
                    {
                        duraciónYcontenido = true;
                    }
                    else if (resultadoTipoContenido == "evento en vivo"&& resultadoDuracionMinutos >= 30 && resultadoDuracionMinutos <= 240)
                    {
                        duraciónYcontenido = true;
                    }
                    else
                    {
                        duraciónYcontenido = false;
                    }

                    if (resultadoNivelProduccion == "bajo" && (resultadoClasificacionEdad == "Todo publico" || resultadoClasificacionEdad == "+13"))
                    {
                        validacionNivelP = true;
                    }
                    else if (resultadoNivelProduccion == "medio" || resultadoNivelProduccion == "alto")
                    {
                        validacionNivelP = true;
                    }
                    else
                    {
                        validacionNivelP = false;
                    }
                    return duraciónYcontenido && clasificacioYhorario && validacionNivelP;
                }
                resultadosValidacionTecnica = validacionTecnica();

                bool impactoAlto = resultadoNivelProduccion == "alto" || resultadoDuracionMinutos > 120 || (resultadoHoraProgamada >= 20 && resultadoHoraProgamada <= 23);
                bool impactoMedio = resultadoNivelProduccion == "medio" || resultadoDuracionMinutos >= 60 && resultadoDuracionMinutos <= 120;
                bool impactoBajo = resultadoNivelProduccion == "bajo" && resultadoDuracionMinutos < 60;
                string clasificacionImpacto(bool impactoAlto, bool impactoMedio, bool impactoBajo)
                {
                    if (!resultadosValidacionTecnica)
                    {
                        return "No válido";
                    }
                    else
                    {
                        if (impactoAlto)
                        {
                            contadorImpactoAlto++;
                            return "Impacto Alto";
                        }
                        else if (impactoMedio)
                        {
                            contadorImppactoMedio++;
                            return "Impacto Medio";
                        }
                        else
                        {
                            contadorImpactoBajo++;
                            return "Impacto Bajo";
                        }
                    }
                }
                resultadoClasificacionImpacto = clasificacionImpacto(impactoAlto, impactoMedio, impactoBajo);

                string decisionFinal()
                {
                    contadorTotalEvaluados++;
                    if (!resultadosValidacionTecnica)
                    {
                        Console.WriteLine("Rechazar-Incumple alguna regla obligatoria");
                        contadorRechazados++;
                        return "Rechazar";
                    }
                    else if (impactoAlto)
                    {
                        Console.WriteLine("Enviar a revisión-Impacto alto");
                        contadorEnRevision++;
                        return "Enviar a revisión";
                    }
                    else if (impactoMedio || impactoBajo)
                    {
                        Console.WriteLine("Publicar: Cumple reglas técnicas e impacto adecuado");
                        contadorPublicados++;
                        return "Publicar";
                    }

                    Console.WriteLine("Publicar con ajustes: Requiere modificación menor");
                    return "Publicar con ajustes";

                }
                resultadoDecisionFinal = decisionFinal();
                break;
            }
        case 2:
            {
                break;
            }
        case 3:
            { 
                if (contadorImpactoAlto== 0 && contadorImppactoMedio ==0 && contadorImpactoBajo==0)
                {
                    ImpactoPredominante = "Sin datos";
                }
                else
                {
                    if (contadorImpactoAlto >= contadorImppactoMedio && contadorImpactoAlto >= contadorImpactoBajo)
                    {
                        ImpactoPredominante = "Impacto Alto";
                    }
                    else if (contadorImppactoMedio >= contadorImpactoAlto && contadorImppactoMedio >= contadorImpactoBajo)
                    {
                        ImpactoPredominante = "Impacto Medio";
                    }
                    else
                    {
                        ImpactoPredominante = "Impacto Bajo";
                    }
                }

                if (contadorPublicados>0 && contadorTotalEvaluados>0)
                {
                    porcentajeAprobacion = contadorPublicados / contadorTotalEvaluados;
                }
                else
                {
                    porcentajeAprobacion = 0;
                }

                Console.WriteLine("Mostrar estadísticas de la sesión");
                Console.WriteLine($"Total evaluados: {contadorTotalEvaluados}");
                Console.WriteLine($"Total Publicados: {contadorPublicados}");
                Console.WriteLine($"Total rechazados: {contadorRechazados}");
                Console.WriteLine($"Total en revision: {contadorEnRevision}");
                Console.WriteLine($"Impacto predominante: {ImpactoPredominante}");
                Console.WriteLine($"Porcentaje de aprobacion: {porcentajeAprobacion}");
                break;
            }
        case 4:
            {
                contadorTotalEvaluados = 0;
                contadorPublicados = 0;
                contadorRechazados = 0;
                contadorEnRevision = 0;
                contadorImpactoAlto = 0;
                contadorImppactoMedio = 0;
                contadorImpactoBajo = 0;
                Console.WriteLine("Se logrado con exito el reinicio de estadisticas");
                break;
            }
        case 5:
            {
                if (contadorImpactoAlto >= 0 && contadorImppactoMedio >= 0 && contadorImpactoBajo >= 0)
                {
                    if (contadorImpactoAlto >= contadorImppactoMedio && contadorImpactoAlto >= contadorImpactoBajo)
                    {
                        ImpactoPredominante = "Impacto Alto";
                    }
                    else if (contadorImppactoMedio >= contadorImpactoAlto && contadorImppactoMedio >= contadorImpactoBajo)
                    {
                        ImpactoPredominante = "Impacto Medio";
                    }
                    else
                    {
                        ImpactoPredominante = "Impacto Bajo";
                    }
                }
                else
                {
                    ImpactoPredominante = "Sin datos";
                }

                if (contadorPublicados > 0 && contadorTotalEvaluados > 0)
                {
                    porcentajeAprobacion = contadorPublicados / contadorTotalEvaluados;
                }
                else
                {
                    porcentajeAprobacion = 0;
                }

                Console.WriteLine("Resumen Final");
                Console.WriteLine("Mostrar estadísticas de la sesión");
                Console.WriteLine($"Total evaluados: {contadorTotalEvaluados}");
                Console.WriteLine($"Total Publicados: {contadorPublicados}");
                Console.WriteLine($"Total rechazados: {contadorRechazados}");
                Console.WriteLine($"Total en revision: {contadorEnRevision}");
                Console.WriteLine($"Impacto predominante: {ImpactoPredominante}");
                Console.WriteLine($"Porcentaje de aprobacion: {porcentajeAprobacion}");
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