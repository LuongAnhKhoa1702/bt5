using Microsoft.EntityFrameworkCore;
using KTGK.Models; // Đảm bảo có namespace này cho Grade và Student

public class ApplicationDbContext : DbContext
{
    // RẤT QUAN TRỌNG: Phải có các DbSet này để EF Core biết về các bảng của bạn
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // LUÔN GỌI DÒNG NÀY

        // Cấu hình chèn dữ liệu mẫu cho Grades
        modelBuilder.Entity<Grade>().HasData(
            new Grade { GradeId = 1, GradeName = "21DTHA1", ImagePath = "/images/grades/lop1.png" },
            new Grade { GradeId = 2, GradeName = "21DTHA2", ImagePath = "/images/grades/lop2.png" },
            new Grade { GradeId = 3, GradeName = "21DTHA3", ImagePath = "/images/grades/lop3.png" },
            new Grade { GradeId = 4, GradeName = "21DTHA4", ImagePath = "/images/grades/lop4.png" },
            new Grade { GradeId = 5, GradeName = "21DTHA5", ImagePath = "/images/grades/lop4.png" }
        );

        // Cấu hình chèn dữ liệu mẫu cho Students
        modelBuilder.Entity<Student>().HasData(
            new Student { StudentId = 1, FirstName = "Khuyên", LastName = "Bùi", GradeId = 1 },
            new Student { StudentId = 2, FirstName = "Toàn", LastName = "Nguyễn", GradeId = 1 },
            new Student { StudentId = 3, FirstName = "Hương", LastName = "Trần", GradeId = 2 },
            new Student { StudentId = 4, FirstName = "Quang", LastName = "Lê", GradeId = 2 },
            new Student { StudentId = 5, FirstName = "Mai", LastName = "Phạm", GradeId = 3 },
            new Student { StudentId = 6, FirstName = "Long", LastName = "Đỗ", GradeId = 3 },
            new Student { StudentId = 7, FirstName = "Thanh", LastName = "Hoàng", GradeId = 4 },
            new Student { StudentId = 8, FirstName = "Vân", LastName = "Ngô", GradeId = 4 },
            new Student { StudentId = 9, FirstName = "Minh", LastName = "Vũ", GradeId = 5 },
            new Student { StudentId = 10, FirstName = "Anh", LastName = "Đặng", GradeId = 5 }
        );
    }
}