/*

Persona persona1 = CrearPersona();
Persona persona2 = new Persona();

persona1.CargarInformacion();
persona2.CargarInformacion();

Console.WriteLine(CompararEdad(persona1, persona2));

string CompararEdad(Persona p1, Persona p2)
{
    if (p1.Edad > p2.Edad)
    {
        return $"La persona mayor es {p1.Nombre}";
    }
    else
    {
        return $"La persona mayor es {p2.Nombre}";
    }
}

Persona CrearPersona()
{
    return new Persona();
}

class Persona
{
    public string Nombre;
    public int Edad;
    public string Telefono;

    public void CargarInformacion()
    {
        Console.Write("Ingrese nombre persona: ");
        Nombre = Console.ReadLine();

        Console.Write("Ingrese edad persona: ");
        Edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese telefono de la persona: ");
        Telefono = Console.ReadLine();
    }
}



 Llamar a la funcion
int dato = Nombre(datos); Si devuelve datos
Nombre(datos); Si NO devuelve datos
 Declarar (crear) la funcion
valor de retorno - Nombre - (parametros){ 
    // codigo
}



// TEORIA DE CLASES

Persona alguien = new Persona();
alguien.Nombre = "Pedro";
class Persona
{
    public string Nombre;
    public int Edad;
}


// parametros compuestos

// DTO -> Data Transfer Object
RectanguloDTO rectangulo = new RectanguloDTO(10, 15, 20, 25);


RectanguloDTO CargarLadosRectangulo()
{

    RectanguloDTO recTemporal = new RectanguloDTO();

    Console.Write("Ingrese lado 1");
    recTemporal.Lado1 = int.Parse(Console.ReadLine());

    Console.Write("Ingrese lado 2");
    recTemporal.Lado2 = int.Parse(Console.ReadLine());

    Console.Write("Ingrese lado 3");
    recTemporal.Lado3 = int.Parse(Console.ReadLine());

    Console.Write("Ingrese lado 4");
    recTemporal.Lado4 = int.Parse(Console.ReadLine());

    return recTemporal;
}

int CalcularPerimetro(RectanguloDTO figura)
{
    int resultado = figura.Lado1 + figura.Lado2 + figura.Lado3 + figura.Lado4;

    return resultado;
}

int CalcularSuperficie(RectanguloDTO figura)
{
    int resultado = figura.Lado1 * figura.Lado2;

    return resultado;
}

class RectanguloDTO
{
    public RectanguloDTO(int lado1, int lado2, int lado3, int lado4)
    {
        Lado1 = lado1;
        Lado2 = lado2;
        Lado3 = lado3;
        Lado4 = lado4;
    }

    public RectanguloDTO()
    {

    }

    public int Lado1 { get; set; }
    public int Lado2 { get; set; }
    public int Lado3 { get; set; }
    public int Lado4 { get; set; }
}

*/


/*
// Validaciones


using FluentValidation;

var secretario = new Usuario();

secretario.Nombre = "";
secretario.Edad = 16;


secretario.Direccion = new Direccion();


EnviarEmail(secretario);

void EnviarEmail(Usuario user)
{
    var validarUsuario = new UsuarioValidator();

    var resultado = validarUsuario.Validate(user, options => options.IncludeRuleSets("DatosPersonales"));


    if (resultado.IsValid)
    {
        Console.WriteLine($"Se envio el email a {user.Nombre} - {user.Edad}");
    }
    else
    {
        foreach (var error in resultado.Errors)
        {
            Console.WriteLine(error.ErrorMessage);
        }
        Console.WriteLine(resultado.ToString());
    }
}



class Usuario
{
    public List<string> Telefonos { get; set; }
    public Direccion Direccion { get; set; }
    public List<Direccion> Direcciones { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Direccion
{
    public string Calle { get; set; }
    public string Ciudad { get; set; }
}



class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        //ruleset
        RuleSet("DatosPersonales", () =>{

            RuleFor(x => x.Nombre)
                .NotNull().WithMessage("No podes dejar nulo el {PropertyName}")
                .NotEmpty().WithMessage("El nombre no puede estar vacio");

            RuleFor(x => x.Edad)
                .GreaterThanOrEqualTo(18).WithMessage("Mayores de 18");

            RuleForEach(x => x.Telefonos)
                        .NotEmpty().WithMessage("El telefono no puede estar vacio");

            RuleFor(x => x.Telefonos)
            .NotNull().WithMessage("El listado de telefonos no puede ser nulo");

            RuleFor(x => x.Direcciones)
            .NotNull().WithMessage("El listado de direcciones no puede ser nulo");

            RuleForEach(x => x.Direcciones)
                .SetValidator(new DireccionValidator());
        });

        RuleFor(x=> x.Direccion).SetValidator(new DireccionValidator());
    }
}

class DireccionValidator : AbstractValidator<Direccion>
{
    public DireccionValidator()
    {
        RuleFor(d => d.Calle)
            .NotEmpty()
            .NotNull();
    }
}
*/



using FluentValidation;

var nuevoAlumno = new Alumno()
{
    Cursos = new List<Asignatura>(),
    Nombre = "Carlos",
    Apellido = "Zanabria"
};

void RegistrarAlumno(Alumno nuevoAlumno)
{
    var validacionAlumno = new AlumnoValidator();

    var resultado = validacionAlumno.Validate(nuevoAlumno);

    if (resultado.IsValid)
    {
        Console.WriteLine("Se registro el alumno");
    }
    else
    {
        Console.WriteLine("Error al registrar alumno");
        Console.WriteLine(resultado.ToString());
    }



}

class Alumno
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public List<Asignatura> Cursos { get; set; }
    public string DNI { get; set; }
}

class Asignatura
{
    public List<Examen> Examenes { get; set; } // Esto ultimo
    public string Nombre { get; set; }
    public string Horarios { get; set; }

}

// Esto ultimo
class Examen
{
    public string Horario { get; set; }
    public int Nota { get; set; }
}



class AlumnoValidator : AbstractValidator<Alumno>
{
    public AlumnoValidator()
    {
        // Reglas

        RuleFor(x => x.Nombre)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(40);
        RuleFor(x => x.Apellido)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(40);
        RuleFor(x => x.Cursos)
            .NotNull();
        RuleFor(x => x.DNI)
            .Length(8, 8);

        RuleForEach(x => x.Cursos).SetValidator(new AsignaturaValidator());
    }
}

class AsignaturaValidator : AbstractValidator<Asignatura>
{
    public AsignaturaValidator()
    {
        RuleForEach(x => x.Examenes).SetValidator(new ExamenValidator());



    }
}

class ExamenValidator : AbstractValidator<Examen>
{
    public ExamenValidator()
    {
        
    }
}



