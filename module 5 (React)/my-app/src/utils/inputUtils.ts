class InputUtils {
  static checkEmailError(email: string) {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (email === "" || email.match(emailRegex)) {
      return "";
    }
    return "Please enter correct email";
  }

  static checkPasswordError(password: string) {
    const passwordRegex =
      /^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[~!@#$%^&*()_+\-=/*-+{}[\]'";:,.<>/?\\|])[a-zA-Z0-9~!@#$%^&*()_+\-=/*-+{}[\]'";:,.<>/?\\|]+$/;

    if (password === "" || password.match(passwordRegex)) {
      return "";
    }
    return "Password should contain digits, capital letters, small letters and special characters";
  }
}

export default InputUtils;
