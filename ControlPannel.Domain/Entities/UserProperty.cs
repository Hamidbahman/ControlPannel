using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPannel.Domain.Entities;

namespace ControlPannel.Domain.Entities;
public class UserProperty
{
    [Key]
    public long UserId { get; private set; }

    [ForeignKey("UserId")]
    public User User { get; private set; } = null!;

    [Required]
    [StringLength(255)]
    public string Password { get; private set; } = null!;

    public long ConfigurationPasswordId { get; private set; }

    [ForeignKey(nameof(ConfigurationPasswordId))]
    public ConfigurationPassword ConfigurationPassword { get; private set; } = null!;

    public UserProperty() { }

    public UserProperty(long userId, string password, long configurationPasswordId)
    {
        UserId = userId;
        Password = password;
        ConfigurationPasswordId = configurationPasswordId;
    }
}
