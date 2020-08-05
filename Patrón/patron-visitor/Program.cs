using System;

namespace patron_visitor
{
    //Para este ejemplo, partiremos de una simplificación de la realidad 
    //Implementamos un Visitor que calcula el precio con IVA incluído de 
    //diferentes productos y servicios

    // Alimentos: 10,50%
    // Servicios: 27%
    // Productos Generales: 21% 

    class Program
    {
        static void Main(string[] args)
        {
            IvaVisitor calcularPrecioConIva = new IvaVisitor();

            Alimento alimento = new Alimento(22m);
            Servicio servicio = new Servicio(33m);
            ProductoGeneral productoGeneral = new ProductoGeneral(12m);

            Console.WriteLine($"El precio del alimento sin IVA es {alimento.ObtenerPrecio()} y con IVA es {alimento.accept(calcularPrecioConIva)}");
            Console.WriteLine($"El precio del servicio sin IVA es {servicio.ObtenerPrecio()} y con IVA es {servicio.accept(calcularPrecioConIva)}");
            Console.WriteLine($"El precio del producto general sin IVA es {productoGeneral.ObtenerPrecio()} y con IVA es {productoGeneral.accept(calcularPrecioConIva)}");

        }
    }
}

public interface Visitor
{

    //Basado en el concepto de sobrecarga. 
    //Usa el métdo correcto según el objeto que se le pase.

    public decimal visit(Alimento alimento);
    public decimal visit(ProductoGeneral produtoGeneral);
    public decimal visit(Servicio servicio);

}


interface Element
{
 
    public decimal accept(Visitor visitor);

}


public class Alimento : Element
{

    private decimal Precio;
    public Alimento(decimal precio)
    {
        Precio = precio;
    }

    public decimal ObtenerPrecio()
    {
        return Precio;
    }

    public decimal accept(Visitor visitor)
    {
        return visitor.visit(this);
    }


}

public class Servicio : Element
{

    private decimal Precio;

    public Servicio(decimal precio)
    {
        Precio = precio;
    }


    public decimal ObtenerPrecio()
    {
        return Precio;
    }
    public decimal accept(Visitor visitor)
    {
        return visitor.visit(this);
    }

}

public class ProductoGeneral : Element
{
    private decimal Precio;

    public ProductoGeneral(decimal precio)
    {
        Precio = precio;
    }

    public decimal ObtenerPrecio()
    {
        return Precio;
    }
    public decimal accept(Visitor visitor)
    {
    
        return visitor.visit(this);
    }
}




public class IvaVisitor : Visitor
{
    public decimal visit(Alimento alimento)
    {
        double procentaje = 0.105;

        double precioConvertidoADouble = Decimal.ToDouble(alimento.ObtenerPrecio());

        decimal impuesto = Convert.ToDecimal(procentaje * precioConvertidoADouble);

        decimal precioImpuestoIncluido = impuesto + alimento.ObtenerPrecio();

        return precioImpuestoIncluido;
    }

    public decimal visit(ProductoGeneral produtoGeneral)
    {
        double procentaje = 0.21;

        double precioConvertidoADouble = Decimal.ToDouble(produtoGeneral.ObtenerPrecio());

        decimal impuesto = Convert.ToDecimal(procentaje * precioConvertidoADouble);

        decimal precioImpuestoIncluido = impuesto + produtoGeneral.ObtenerPrecio();

        return precioImpuestoIncluido;
    }

    public decimal visit(Servicio servicio)
    {
        double porcentaje = 0.27;

        double precioConvertidoADouble = Decimal.ToDouble(servicio.ObtenerPrecio());

        decimal impuesto = Convert.ToDecimal(porcentaje * precioConvertidoADouble);

        decimal precioImpuestoIncluido = impuesto + servicio.ObtenerPrecio();

        return precioImpuestoIncluido;
    }



}
