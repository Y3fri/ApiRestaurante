using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurant.Models
{
    public partial class RestauranteBDContext : DbContext
    {
        public RestauranteBDContext()
        {
        }

        public RestauranteBDContext(DbContextOptions<RestauranteBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaestroDepartamento> MaestroDepartamentos { get; set; } = null!;
        public virtual DbSet<MaestroMunicipio> MaestroMunicipios { get; set; } = null!;
        public virtual DbSet<MaestroPai> MaestroPais { get; set; } = null!;
        public virtual DbSet<MenuAcompaniamiento> MenuAcompaniamientos { get; set; } = null!;
        public virtual DbSet<MenuCategorium> MenuCategoria { get; set; } = null!;
        public virtual DbSet<MenuDescuento> MenuDescuentos { get; set; } = null!;
        public virtual DbSet<MenuModificacion> MenuModificacions { get; set; } = null!;
        public virtual DbSet<MenuProducto> MenuProductos { get; set; } = null!;
        public virtual DbSet<MenuProductoAcompaniamiento> MenuProductoAcompaniamientos { get; set; } = null!;
        public virtual DbSet<MenuProductoModificacion> MenuProductoModificacions { get; set; } = null!;
        public virtual DbSet<PedidoAcompaniamineto> PedidoAcompaniaminetos { get; set; } = null!;
        public virtual DbSet<PedidoEstado> PedidoEstados { get; set; } = null!;
        public virtual DbSet<PedidoInformacion> PedidoInformacions { get; set; } = null!;
        public virtual DbSet<PedidoModificacion> PedidoModificacions { get; set; } = null!;
        public virtual DbSet<PedidoProducto> PedidoProductos { get; set; } = null!;
        public virtual DbSet<PedidoTipo> PedidoTipos { get; set; } = null!;
        public virtual DbSet<PedidoTipoPago> PedidoTipoPagos { get; set; } = null!;
        public virtual DbSet<RestauranteInformacion> RestauranteInformacions { get; set; } = null!;
        public virtual DbSet<RestauranteSede> RestauranteSedes { get; set; } = null!;
        public virtual DbSet<SsoModulo> SsoModulos { get; set; } = null!;
        public virtual DbSet<SsoRol> SsoRols { get; set; } = null!;
        public virtual DbSet<SsoRolModulo> SsoRolModulos { get; set; } = null!;
        public virtual DbSet<SsoUsuario> SsoUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-32FLDL7;Database=RestauranteBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaestroDepartamento>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK_MaestroDepartamento");

                entity.ToTable("Maestro.Departamento");

                entity.Property(e => e.DepId).HasColumnName("depId");

                entity.Property(e => e.DepCodigoDane)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("dep_codigo_dane");

                entity.Property(e => e.DepNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("dep_nombre");

                entity.Property(e => e.DepPais).HasColumnName("depPais");

                entity.HasOne(d => d.DepPaisNavigation)
                    .WithMany(p => p.MaestroDepartamentos)
                    .HasForeignKey(d => d.DepPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maestro.Departamento_Maestro.Pais");
            });

            modelBuilder.Entity<MaestroMunicipio>(entity =>
            {
                entity.HasKey(e => e.MunId)
                    .HasName("PK_MaestroMunicipio");

                entity.ToTable("Maestro.Municipio");

                entity.Property(e => e.MunId).HasColumnName("munId");

                entity.Property(e => e.MunCodigoDane)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mun_codigo_dane");

                entity.Property(e => e.MunDepartamento).HasColumnName("mun_departamento");

                entity.Property(e => e.MunNombre)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("mun_nombre");

                entity.HasOne(d => d.MunDepartamentoNavigation)
                    .WithMany(p => p.MaestroMunicipios)
                    .HasForeignKey(d => d.MunDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maestro.Municipio_Maestro.Departamento");
            });

            modelBuilder.Entity<MaestroPai>(entity =>
            {
                entity.HasKey(e => e.PaiId);

                entity.ToTable("Maestro.Pais");

                entity.Property(e => e.PaiId).HasColumnName("pai_id");

                entity.Property(e => e.PaiNombre)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("pai_nombre");
            });

            modelBuilder.Entity<MenuAcompaniamiento>(entity =>
            {
                entity.HasKey(e => e.AcoId);

                entity.ToTable("Menu.Acompaniamiento");

                entity.Property(e => e.AcoId).HasColumnName("aco_id");

                entity.Property(e => e.AcaPrecio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("aca_precio");

                entity.Property(e => e.AcoNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aco_nombre");
            });

            modelBuilder.Entity<MenuCategorium>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("Menu.Categoria");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CarSede).HasColumnName("car_sede");

                entity.Property(e => e.CatDescripcion)
                    .IsUnicode(false)
                    .HasColumnName("cat_descripcion");

                entity.Property(e => e.CatEstado).HasColumnName("cat_estado");

                entity.Property(e => e.CatNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cat_nombre");

                entity.HasOne(d => d.CarSedeNavigation)
                    .WithMany(p => p.MenuCategoria)
                    .HasForeignKey(d => d.CarSede)
                    .HasConstraintName("FK_Menu.Categoria_Restaurante.Sede");
            });

            modelBuilder.Entity<MenuDescuento>(entity =>
            {
                entity.HasKey(e => e.DesId);

                entity.ToTable("Menu.Descuento");

                entity.Property(e => e.DesId).HasColumnName("des_id");

                entity.Property(e => e.DesEstado).HasColumnName("des_estado");

                entity.Property(e => e.DesFechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("des_fecha_final");

                entity.Property(e => e.DesFechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("des_fecha_inicio");

                entity.Property(e => e.DesPorcentaje)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("des_porcentaje");

                entity.Property(e => e.DesProducto).HasColumnName("des_producto");

                entity.HasOne(d => d.DesProductoNavigation)
                    .WithMany(p => p.MenuDescuentos)
                    .HasForeignKey(d => d.DesProducto)
                    .HasConstraintName("FK_Menu.Descuento_Menu.Producto");
            });

            modelBuilder.Entity<MenuModificacion>(entity =>
            {
                entity.HasKey(e => e.ModId);

                entity.ToTable("Menu.Modificacion");

                entity.Property(e => e.ModId).HasColumnName("mod_id");

                entity.Property(e => e.ModNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("mod_nombre");
            });

            modelBuilder.Entity<MenuProducto>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("Menu.Producto");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.ProCategoria).HasColumnName("pro_categoria");

                entity.Property(e => e.ProDescripcion)
                    .IsUnicode(false)
                    .HasColumnName("pro_descripcion");

                entity.Property(e => e.ProEstado).HasColumnName("pro_estado");

                entity.Property(e => e.ProFoto)
                    .IsUnicode(false)
                    .HasColumnName("pro_foto");

                entity.Property(e => e.ProNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("pro_nombre");

                entity.Property(e => e.ProPrecio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("pro_precio");

                entity.Property(e => e.ProSede).HasColumnName("pro_sede");

                entity.Property(e => e.ProTiempoPreparacion).HasColumnName("pro_tiempo_preparacion");

                entity.Property(e => e.ProVideo)
                    .IsUnicode(false)
                    .HasColumnName("pro_video");

                entity.HasOne(d => d.ProCategoriaNavigation)
                    .WithMany(p => p.MenuProductos)
                    .HasForeignKey(d => d.ProCategoria)
                    .HasConstraintName("FK_Menu.Producto_Menu.Categoria");

                entity.HasOne(d => d.ProSedeNavigation)
                    .WithMany(p => p.MenuProductos)
                    .HasForeignKey(d => d.ProSede)
                    .HasConstraintName("FK_Menu.Producto_Restaurante.Sede");
            });

            modelBuilder.Entity<MenuProductoAcompaniamiento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Menu.Producto_acompaniamiento");

                entity.Property(e => e.PracAcompaniamiento).HasColumnName("prac_acompaniamiento");

                entity.Property(e => e.PracProducto).HasColumnName("prac_producto");

                entity.HasOne(d => d.PracAcompaniamientoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PracAcompaniamiento)
                    .HasConstraintName("FK_Menu.Producto_acompaniamiento_Menu.Acompaniamiento");

                entity.HasOne(d => d.PracProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PracProducto)
                    .HasConstraintName("FK_Menu.Producto_acompaniamiento_Menu.Producto");
            });

            modelBuilder.Entity<MenuProductoModificacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Menu.Producto_modificacion");

                entity.Property(e => e.PrmoModificacion).HasColumnName("prmo_modificacion");

                entity.Property(e => e.PrmoProducto).HasColumnName("prmo_producto");

                entity.HasOne(d => d.PrmoModificacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PrmoModificacion)
                    .HasConstraintName("FK_Menu.Producto_modificacion_Menu.Modificacion");

                entity.HasOne(d => d.PrmoProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PrmoProducto)
                    .HasConstraintName("FK_Menu.Producto_modificacion_Menu.Producto");
            });

            modelBuilder.Entity<PedidoAcompaniamineto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pedido.Acompaniamineto");

                entity.Property(e => e.AcoAcompaniamiento).HasColumnName("aco_acompaniamiento");

                entity.Property(e => e.AcoCantidad).HasColumnName("aco_cantidad");

                entity.Property(e => e.AcoProducto).HasColumnName("aco_producto");

                entity.HasOne(d => d.AcoAcompaniamientoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AcoAcompaniamiento)
                    .HasConstraintName("FK_Pedido.Acompaniamineto_Menu.Acompaniamiento");

                entity.HasOne(d => d.AcoProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AcoProducto)
                    .HasConstraintName("FK_Pedido.Acompaniamineto_Pedido.Producto");
            });

            modelBuilder.Entity<PedidoEstado>(entity =>
            {
                entity.HasKey(e => e.EstId);

                entity.ToTable("Pedido.Estado");

                entity.Property(e => e.EstId).HasColumnName("est_id");

                entity.Property(e => e.EstDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("est_descripcion");

                entity.Property(e => e.EstEstado).HasColumnName("est_estado");

                entity.Property(e => e.EstNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("est_nombre");
            });

            modelBuilder.Entity<PedidoInformacion>(entity =>
            {
                entity.HasKey(e => e.InfId);

                entity.ToTable("Pedido.Informacion");

                entity.Property(e => e.InfId).HasColumnName("inf_id");

                entity.Property(e => e.InfDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("inf_direccion");

                entity.Property(e => e.InfEstado).HasColumnName("inf_estado");

                entity.Property(e => e.InfMunicipio).HasColumnName("inf_municipio");

                entity.Property(e => e.InfNombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inf_nombre_cliente");

                entity.Property(e => e.InfNumeroMesa)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("inf_numero_mesa");

                entity.Property(e => e.InfNumeroPiso)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("inf_numero_piso");

                entity.Property(e => e.InfTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("inf_telefono");

                entity.Property(e => e.InfTipo).HasColumnName("inf_tipo");

                entity.Property(e => e.InfTipoPago).HasColumnName("inf_tipo_pago");

                entity.HasOne(d => d.InfEstadoNavigation)
                    .WithMany(p => p.PedidoInformacions)
                    .HasForeignKey(d => d.InfEstado)
                    .HasConstraintName("FK_Pedido.Informacion_Pedido.Estado");

                entity.HasOne(d => d.InfMunicipioNavigation)
                    .WithMany(p => p.PedidoInformacions)
                    .HasForeignKey(d => d.InfMunicipio)
                    .HasConstraintName("FK_Pedido.Informacion_Maestro.Municipio");

                entity.HasOne(d => d.InfTipoNavigation)
                    .WithMany(p => p.PedidoInformacions)
                    .HasForeignKey(d => d.InfTipo)
                    .HasConstraintName("FK_Pedido.Informacion_Pedido.Tipo");

                entity.HasOne(d => d.InfTipoPagoNavigation)
                    .WithMany(p => p.PedidoInformacions)
                    .HasForeignKey(d => d.InfTipoPago)
                    .HasConstraintName("FK_Pedido.Informacion_Pedido.Tipo_pago");
            });

            modelBuilder.Entity<PedidoModificacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pedido.Modificacion");

                entity.Property(e => e.AcoCantidad).HasColumnName("aco_cantidad");

                entity.Property(e => e.ModModificacion).HasColumnName("mod_modificacion");

                entity.Property(e => e.ModProducto).HasColumnName("mod_producto");

                entity.HasOne(d => d.ModModificacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ModModificacion)
                    .HasConstraintName("FK_Pedido.Modificacion_Menu.Modificacion");

                entity.HasOne(d => d.ModProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ModProducto)
                    .HasConstraintName("FK_Pedido.Modificacion_Pedido.Producto");
            });

            modelBuilder.Entity<PedidoProducto>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("Pedido.Producto");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.ProEstado).HasColumnName("pro_estado");

                entity.Property(e => e.ProProducto).HasColumnName("pro_producto");

                entity.Property(e => e.ProSolicitudAdicional)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pro_solicitud_adicional");

                entity.HasOne(d => d.ProEstadoNavigation)
                    .WithMany(p => p.PedidoProductos)
                    .HasForeignKey(d => d.ProEstado)
                    .HasConstraintName("FK_Pedido.Producto_Pedido.Estado");

                entity.HasOne(d => d.ProProductoNavigation)
                    .WithMany(p => p.PedidoProductos)
                    .HasForeignKey(d => d.ProProducto)
                    .HasConstraintName("FK_Pedido.Producto_Menu.Producto");
            });

            modelBuilder.Entity<PedidoTipo>(entity =>
            {
                entity.HasKey(e => e.TipId);

                entity.ToTable("Pedido.Tipo");

                entity.Property(e => e.TipId).HasColumnName("tip_id");

                entity.Property(e => e.TipDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tip_descripcion");

                entity.Property(e => e.TipEstado).HasColumnName("tip_estado");

                entity.Property(e => e.TipNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tip_nombre");
            });

            modelBuilder.Entity<PedidoTipoPago>(entity =>
            {
                entity.HasKey(e => e.TipaId);

                entity.ToTable("Pedido.Tipo_pago");

                entity.Property(e => e.TipaId).HasColumnName("tipa_id");

                entity.Property(e => e.TipaDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tipa_descripcion");

                entity.Property(e => e.TipaEstado).HasColumnName("tipa_estado");

                entity.Property(e => e.TipaNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipa_nombre");
            });

            modelBuilder.Entity<RestauranteInformacion>(entity =>
            {
                entity.HasKey(e => e.InfId);

                entity.ToTable("Restaurante.Informacion");

                entity.Property(e => e.InfId).HasColumnName("inf_id");

                entity.Property(e => e.InfDireccionPrincipal)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("inf_direccion_principal");

                entity.Property(e => e.InfEmailPrincipal)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("inf_email_principal");

                entity.Property(e => e.InfLogo)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("inf_logo");

                entity.Property(e => e.InfMunicipio).HasColumnName("inf_municipio");

                entity.Property(e => e.InfRazonSocial)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("inf_razon_social");

                entity.Property(e => e.InfTelefonoPrincipal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inf_telefono_principal");

                entity.Property(e => e.IntNit)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("int_nit");

                entity.HasOne(d => d.InfMunicipioNavigation)
                    .WithMany(p => p.RestauranteInformacions)
                    .HasForeignKey(d => d.InfMunicipio)
                    .HasConstraintName("FK_Restaurante.Informacion_Maestro.Municipio");
            });

            modelBuilder.Entity<RestauranteSede>(entity =>
            {
                entity.HasKey(e => e.SedId);

                entity.ToTable("Restaurante.Sede");

                entity.Property(e => e.SedId).HasColumnName("sed_id");

                entity.Property(e => e.SedEmail)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("sed_email");

                entity.Property(e => e.SedInfDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("sed_inf_direccion");

                entity.Property(e => e.SedInfTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sed_inf_telefono");

                entity.Property(e => e.SedInfirmation).HasColumnName("sed_infirmation");

                entity.Property(e => e.SedUbicacionGoogle)
                    .IsUnicode(false)
                    .HasColumnName("sed_ubicacion_google");

                entity.HasOne(d => d.SedInfirmationNavigation)
                    .WithMany(p => p.RestauranteSedes)
                    .HasForeignKey(d => d.SedInfirmation)
                    .HasConstraintName("FK_Restaurante.Sede_Restaurante.Informacion");
            });

            modelBuilder.Entity<SsoModulo>(entity =>
            {
                entity.HasKey(e => e.ModId);

                entity.ToTable("SSO.Modulo");

                entity.Property(e => e.ModId).HasColumnName("mod_id");

                entity.Property(e => e.ModDescripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mod_descripcion");

                entity.Property(e => e.ModNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mod_nombre");
            });

            modelBuilder.Entity<SsoRol>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("SSO.Rol");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.RolDescripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("rol_descripcion");

                entity.Property(e => e.RolNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol_nombre");
            });

            modelBuilder.Entity<SsoRolModulo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SSO.Rol_Modulo");

                entity.Property(e => e.RomoModulo).HasColumnName("romo_Modulo");

                entity.Property(e => e.RomoRol).HasColumnName("romo_Rol");

                entity.HasOne(d => d.RomoModuloNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RomoModulo)
                    .HasConstraintName("FK_SSO.Rol_Modulo_SSO.Modulo");

                entity.HasOne(d => d.RomoRolNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RomoRol)
                    .HasConstraintName("FK_SSO.Rol_Modulo_SSO.Rol");
            });

            modelBuilder.Entity<SsoUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("SSO.Usuario");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.UsuApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usu_apellido");

                entity.Property(e => e.UsuContrasenia)
                    .IsUnicode(false)
                    .HasColumnName("usu_contrasenia");

                entity.Property(e => e.UsuDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usu_documento");

                entity.Property(e => e.UsuNickname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usu_nickname");

                entity.Property(e => e.UsuNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usu_nombre");

                entity.Property(e => e.UsuRestaurante).HasColumnName("usu_restaurante");

                entity.Property(e => e.UsuRol).HasColumnName("usu_rol");

                entity.HasOne(d => d.UsuRestauranteNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuRestaurante)
                    .HasConstraintName("FK_SSO.Usuario_Restaurante.Informacion");

                entity.HasOne(d => d.UsuRolNavigation)
                    .WithMany(p => p.SsoUsuarios)
                    .HasForeignKey(d => d.UsuRol)
                    .HasConstraintName("FK_SSO.Usuario_SSO.Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
