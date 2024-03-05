using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaVenta.Entity
{
    public partial class DBVENTAContext : DbContext
    {
        public DBVENTAContext()
        {
        }

        public DBVENTAContext(DbContextOptions<DBVENTAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Configuracion> Configuracions { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Negocio> Negocios { get; set; } = null!;
        public virtual DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<RolMenu> RolMenus { get; set; } = null!;
        public virtual DbSet<TipoDocumentoVentum> TipoDocumentoVenta { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FU3CFO0;Initial Catalog=DBVENTA;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CEB7741D7");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Configuracion");

                entity.Property(e => e.Propiedad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("propiedad");

                entity.Property(e => e.Recurso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("recurso");

                entity.Property(e => e.Valor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PK__DetalleV__BFE2843FC996A43C");

                entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CategoriaProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoriaProducto");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProducto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.MarcaProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marcaProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__DetalleVe__idVen__571DF1D5");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__Menu__C26AF483077FAEE9");

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.Controlador)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("controlador");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Icono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("icono");

                entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");

                entity.Property(e => e.PaginaAccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("paginaAccion");

                entity.HasOne(d => d.IdMenuPadreNavigation)
                    .WithMany(p => p.InverseIdMenuPadreNavigation)
                    .HasForeignKey(d => d.IdMenuPadre)
                    .HasConstraintName("FK__Menu__idMenuPadr__37A5467C");
            });

            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.HasKey(e => e.IdNegocio)
                    .HasName("PK__Negocio__70E1E10778503BF9");

                entity.ToTable("Negocio");

                entity.Property(e => e.IdNegocio)
                    .ValueGeneratedNever()
                    .HasColumnName("idNegocio");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreLogo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreLogo");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.PorcentajeImpuesto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("porcentajeImpuesto");

                entity.Property(e => e.SimboloMoneda)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("simboloMoneda");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.UrlLogo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlLogo");
            });

            modelBuilder.Entity<NumeroCorrelativo>(entity =>
            {
                entity.HasKey(e => e.IdNumeroCorrelativo)
                    .HasName("PK__NumeroCo__25FB547EE309C8D7");

                entity.ToTable("NumeroCorrelativo");

                entity.Property(e => e.IdNumeroCorrelativo).HasColumnName("idNumeroCorrelativo");

                entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaActualizacion");

                entity.Property(e => e.Gestion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gestion");

                entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A1327A472084");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.CodigoBarra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoBarra");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreImagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlImagen");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Producto__idCate__49C3F6B7");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F76AA8BC769");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RolMenu>(entity =>
            {
                entity.HasKey(e => e.IdRolMenu)
                    .HasName("PK__RolMenu__CD2045D80CB3027F");

                entity.ToTable("RolMenu");

                entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK__RolMenu__idMenu__3F466844");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__RolMenu__idRol__3E52440B");
            });

            modelBuilder.Entity<TipoDocumentoVentum>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumentoVenta)
                    .HasName("PK__TipoDocu__A9D59AEE0DD42052");

                entity.Property(e => e.IdTipoDocumentoVenta).HasColumnName("idTipoDocumentoVenta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6B33C4CDA");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreFoto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreFoto");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.UrlFoto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlFoto");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__idRol__4316F928");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__077D56141BB0CA01");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.DocumentoCliente)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("documentoCliente");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTipoDocumentoVenta).HasColumnName("idTipoDocumentoVenta");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.ImpuestoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("impuestoTotal");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.NumeroVenta)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("numeroVenta");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdTipoDocumentoVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdTipoDocumentoVenta)
                    .HasConstraintName("FK__Venta__idTipoDoc__52593CB8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Venta__idUsuario__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
