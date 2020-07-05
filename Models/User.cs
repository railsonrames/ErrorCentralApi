using System;
using System.Collections.Generic;

namespace ErrorCentralApi.Models
{
  public class User
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    public virtual ICollection<Error> Errors { get; set; }
  }
}
