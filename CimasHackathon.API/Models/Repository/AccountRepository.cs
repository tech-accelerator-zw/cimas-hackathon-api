using Microsoft.EntityFrameworkCore;
using CimasHackathon.API.Enums;
using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using CimasHackathon.API.Services;

namespace CimasHackathon.API.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly ICodeGeneratorService _codeGeneratorService;
        private readonly IEmailService _emailService;

        public AccountRepository(AppDbContext context, IConfiguration configuration, IPasswordService passwordService, IJwtService jwtService, ICodeGeneratorService codeGeneratorService, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _codeGeneratorService = codeGeneratorService;
            _emailService = emailService;
        }

        public async Task<Result<Account>> AddAsync(Account account)
        {
            try
            {
                //if (!IsUniqueUser(account.Email!))
                //    return new Result<Account>(false, "An account with that email already exists!");

                account.Password = _passwordService.HashPassword(account.Password!);

                await _context.Accounts!.AddAsync(account);

                var code = await _codeGeneratorService.GenerateVerificationCode();

                await _context.GeneratedCodes!.AddAsync(new GeneratedCode
                {
                    Code = code,
                    UserEmail = account.Email,
                    DateCreated = DateTime.Now
                });

                await _context.SaveChangesAsync();

                await _emailService.SendEmailAsync(new EmailRequest
                {
                    To = account.Email,
                    Subject = _configuration["EmailService:ConfirmAccountSubject"],
                    Body = string.Format(_configuration["EmailService:ConfirmAccountBody"], "", code)
                });

                return new Result<Account>(account, "Account created successfully!");
            }
            catch (Exception ex)
            {
                return new Result<Account>(false, ex.ToString());
            }
        }

        public Task<Result<bool>> DeleteAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }

        //public async Task<Result<Account>> ConfirmAccountAsync(ConfirmAccountRequest confirmAccount)
        //{
        //    var account = await _context.Accounts!.Where(tsuro => tsuro.Email == confirmAccount.Email).FirstOrDefaultAsync();
        //    if (account == null) return new Result<Account>(false, "User account not found!");

        //    var code = await _context.GeneratedCodes!.Where(x => x.UserEmail == confirmAccount.Email && x.Code == confirmAccount.ConfirmationCode).FirstOrDefaultAsync();
        //    if (code == null) return new Result<Account>(false, "Invalid code provided!");

        //    account.Status = AccountStatus.PendingDetails;
        //    _context.Accounts!.Update(account);

        //    await _context.SaveChangesAsync();

        //    await _emailService.SendEmailAsync(new EmailRequest
        //    {
        //        Body = _configuration["EmailService:PendingApprovalBody"],
        //        Subject = _configuration["EmailService:PendingApprovalSubject"],
        //        To = account.Email
        //    });

        //    return new Result<Account>(account, "Registration Complete. Please wait for approval!");
        //}

        //public async Task<Result<Account>> LoginAsync(LoginRequest login)
        //{
        //    var account = await _context.Accounts!
        //        .Where(x => x.Email == login.Email)
        //        .Include(x => x.Role)
        //        .FirstOrDefaultAsync();

        //    if (account == null || _passwordService.VerifyHash(login.Password!, account!.Password!) == false)
        //        return new Result<Account>(false, "Username or password is incorrect!");

        //    if (account.Status != AccountStatus.Incomplete) account.Token = await _jwtService.GenerateToken(account);
        //    account.Password = "*************";

        //    return new Result<Account>(account);
        //}

        //private bool IsUniqueUser(string email)
        //{
        //    var user = _context.Accounts!.SingleOrDefault(x => x.Email == email);

        //    if (user == null) return true;
        //    return false;
        //}

        //public async Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePassword)
        //{
        //    var account = await GetByIdAsync(changePassword.UserId);
        //    if (!account.Success) return account;

        //    if (_passwordService.VerifyHash(changePassword.OldPassword!, account.Data!.Password!) == false)
        //        return new Result<Account>(false, "Old password mismatch");

        //    account.Data.Password = _passwordService.HashPassword(changePassword.NewPassword!);

        //    _context.Accounts!.Update(account.Data);
        //    await _context.SaveChangesAsync();

        //    return new Result<Account>(account.Data);
        //}

        //public async Task<Result<string>> ResendOtpAsync(string email)
        //{
        //    var account = await _context.Accounts!.Where(x => x.Email!.Equals(email)).FirstOrDefaultAsync();
        //    if (account == null) return new Result<string>(false, "Please ensure you have recently created an account with us!");

        //    var otpCode = await _context.GeneratedCodes!.Where(x => x.UserEmail == email && x.DateCreated.AddMinutes(5) >= DateTime.Now).FirstOrDefaultAsync();

        //    if (otpCode == null)
        //    {
        //        otpCode!.Code = await _codeGeneratorService.GenerateVerificationCode();

        //        await _context.GeneratedCodes!.AddAsync(new GeneratedCode
        //        {
        //            Code = otpCode!.Code,
        //            UserEmail = email,
        //            DateCreated = DateTime.Now
        //        });

        //        await _context.SaveChangesAsync();
        //    }

        //    var emailResult = await _emailService.SendEmailAsync(new EmailRequest
        //    {
        //        Body = string.Format(_configuration["EmailService:ResetCodeBody"], otpCode!.Code),
        //        Subject = _configuration["EmailService:ResetCodeSubject"],
        //        To = email
        //    });

        //    if (!emailResult.Success) return emailResult;

        //    return new Result<string>("Verification code has been sent to your email.");
        //}

        //public async Task<Result<string>> GetResetPasswordCodeAsync(string email)
        //{
        //    var account = await _context.Accounts!.SingleOrDefaultAsync(y => y.Email == email);
        //    if (account == null) return new Result<string>(false, "User account does not exist.");

        //    var verificationCode = await _codeGeneratorService.GenerateVerificationCode();

        //    await _context.GeneratedCodes!.AddAsync(new GeneratedCode
        //    {
        //        Code = verificationCode,
        //        UserEmail = account.Email,
        //        DateCreated = DateTime.Now
        //    });

        //    await _context.SaveChangesAsync();

        //    var emailResult = await _emailService.SendEmailAsync(new EmailRequest
        //    {
        //        Body = string.Format(_configuration["EmailService:ResetCodeBody"], verificationCode),
        //        Subject = _configuration["EmailService:ResetCodeSubject"],
        //        To = account.Email
        //    });

        //    if (!emailResult.Success) return emailResult;

        //    return new Result<string>("Verification code has been sent to your email.");
        //}

        //public async Task<Result<Account>> ResetPasswordAsync(ResetPasswordRequest resetPassword)
        //{
        //    var account = await _context.Accounts!.Where(x => x.Email == resetPassword.UserEmail).FirstOrDefaultAsync();
        //    if (account == null) return new Result<Account>(false, "Whoaa! How did you get here?");

        //    var verifyCode = await _context.GeneratedCodes!
        //        .Where(x => x.UserEmail == account.Email &&
        //        x.DateCreated.AddMinutes(5) >= DateTime.Now &&
        //        x.Code == resetPassword.VerificationCode)
        //        .FirstOrDefaultAsync();

        //    if (verifyCode == null) return new Result<Account>(false, "Invalid password reset code provided.");

        //    account!.Password = _passwordService.HashPassword(resetPassword.NewPassword!);

        //    _context.Update(account);
        //    await _context.SaveChangesAsync();

        //    return new Result<Account>(account, "Your password has been resetted successfully.");
        //}

        public async Task<Result<Account>> GetByIdAsync(int id)
        {
            var account = await _context.Accounts!.FindAsync(id);
            if (account == null) return new Result<Account>(false, "Account not found.");

            return new Result<Account>(account);
        }

        public async Task<Result<Patient>> PatientLoginAsync(PatientLoginRequest request)
        {
            var patient = await _context.Patients!
                .Where(tsuro => tsuro.Account!.Email == request.Email)
                .Include(x => x.Account)
                .FirstOrDefaultAsync();
            
            if (patient == null) return new Result<Patient>(false, "User account not found!");

            var code = await _context.GeneratedCodes!.Where(x => x.UserEmail == request.Email && x.Code == request.Otp).FirstOrDefaultAsync();
            if (code == null) return new Result<Patient>(false, "Invalid code provided!");

            patient.Account!.Token = await _jwtService.GenerateToken(patient.Account);

            return new Result<Patient>(patient);
        }

        public async Task<Result<string>> PatientOtpAsync(string cimasNumber)
        {
            var patient = await _context.Patients!.Include(x => x.Account).Where(tsuro => tsuro.Account!.CimasNumber == cimasNumber).FirstOrDefaultAsync();
            if (patient == null) return new Result<string>(false, "User account not found!");

            var verificationCode = await _codeGeneratorService.GenerateVerificationCode();

            await _context.GeneratedCodes!.AddAsync(new GeneratedCode
            {
                Code = verificationCode,
                UserEmail = patient.Account!.Email,
                DateCreated = DateTime.Now
            });

            await _context.SaveChangesAsync();

            var emailResult = await _emailService.SendEmailAsync(new EmailRequest
            {
                Body = string.Format(_configuration["EmailService:OtpBody"], patient.Name, verificationCode),
                Subject = _configuration["EmailService:OtpSubject"],
                To = patient.Account.Email
            });

            if (!emailResult.Success) return emailResult;

            return new Result<string>("Verification code has been sent to your email.");
        }

        public async Task<Result<Doctor>> DoctorLoginAsync(DoctorLoginRequest login)
        {
            var doctor = await _context.Doctors!.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (doctor != null && login.Password == "qwerty123")
            {
                doctor.Token = await _jwtService.GenerateToken(new Account
                {
                    Id = doctor.Id,
                    Email = doctor.Email
                });

                return new Result<Doctor>(doctor);
            }

            return new Result<Doctor>(false, "Invalid email or password provided.");
        }
    }
}