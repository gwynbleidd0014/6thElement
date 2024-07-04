"use client";

import { registerAction } from "@/lib/actions";
import { UserInfo } from "@/types/user-type";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { ChangeEvent, useState } from "react";
import { FaFacebookF, FaGoogle } from "react-icons/fa";

const SignupComp = () => {
  const [userInfo, setUserInfo] = useState<UserInfo>({
    age: null,
    userName: "",
    email: "",
    password: "",
  });

  const [errors, setErrors] = useState({
    age: "",
    userName: "",
    email: "",
    password: "",
  });

  const router = useRouter();

  const validateInputs = () => {
    let valid = true;
    let newErrors = { age: "", userName: "", email: "", password: "" };

    if (!userInfo.age || isNaN(userInfo.age)) {
      newErrors.age = "Age must be a number.";
      valid = false;
    }

    if (!userInfo.userName || typeof userInfo.userName !== "string") {
      newErrors.userName = "Name must be a string.";
      valid = false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!userInfo.email || !emailRegex.test(userInfo.email)) {
      newErrors.email = "Invalid email format.";
      valid = false;
    }

    const passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$/;
    if (!userInfo.password || !passwordRegex.test(userInfo.password)) {
      newErrors.password =
        "Password must include a capital letter, a number, a special character, and be at least 8 characters long.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUserInfo({ ...userInfo, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (validateInputs()) {
      await registerAction(userInfo);
      router.push("/dashboard/learn");
    } else {
      console.log("Form is invalid. Fix errors and try again.");
    }
  };

  return (
    <main className="p-8">
      <div className="flex justify-end">
        <Link
          href="/auth/login"
          className="uppercase text-[#1CB0F6] font-bold text-[16px] p-4 px-6 rounded-2xl border-2 border-[#AFAFAF] hover:bg-[#E5E5E5] duration-300"
        >
          Log in
        </Link>
      </div>
      <section>
        <div className="flex flex-col items-center p-6">
          <form
            className="w-[380px] flex flex-col gap-4"
            onSubmit={handleSubmit}
          >
            <h1 className="text-[26px] font-extrabold mt-2 mb-4 text-center text-[#333333]">
              Create your profile
            </h1>
            <input
              type="number"
              name="age"
              value={userInfo.age !== null ? userInfo.age : ""}
              onChange={handleChange}
              placeholder="Age"
              min={0}
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            {errors.age && <p className="text-red-500">{errors.age}</p>}
            <input
              type="text"
              name="userName"
              value={userInfo.userName}
              onChange={handleChange}
              placeholder="Name (optional)"
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            {errors.userName && (
              <p className="text-red-500">{errors.userName}</p>
            )}
            <input
              type="email"
              name="email"
              value={userInfo.email}
              onChange={handleChange}
              placeholder="Email"
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            {errors.email && <p className="text-red-500">{errors.email}</p>}
            <input
              type="password"
              name="password"
              value={userInfo.password}
              onChange={handleChange}
              placeholder="Password"
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            {errors.password && (
              <p className="text-red-500">{errors.password}</p>
            )}
            <button
              type="submit"
              className="bg-[#1CB0F6] hover:bg-[#77ccf3] duration-300 text-white p-2 py-3 rounded-xl items-center text-center uppercase font-bold tracking-widest w-full"
            >
              Create acount
            </button>
            <div className="text-[#AFAFAF]">
              <h2 className="flex flex-row flex-nowrap items-center">
                <span className="flex-grow block border-t-2 border-[#AFAFAF]"></span>
                <span className="m-2">OR</span>
                <span className="flex-grow block border-t-2 border-[#AFAFAF]"></span>
              </h2>
            </div>
            <button className="flex gap-2 justify-center bg-white hover:bg-[#AFAFAF] duration-300 text-blue p-2 py-3 rounded-xl items-center text-center font-bold tracking-widest shadow-[0_6px_0] shadow-[#AFAFAF] w-full">
              <FaFacebookF /> facebook
            </button>
            <button className="flex gap-2 justify-center bg-white hover:bg-[#AFAFAF] duration-300 text-blue p-2 py-3 rounded-xl items-center text-center font-bold tracking-widest shadow-[0_6px_0] shadow-[#AFAFAF] w-full">
              <FaGoogle />
              Google
            </button>
            <div className="text-center text-[#AFAFAF] text-[14px]">
              <span>
                By signing in to Duolingo, you agree to our Terms and Privacy
                Policy.
              </span>
            </div>
            <div className="text-center text-[#AFAFAF] text-[14px]">
              <span>
                This site is protected by reCAPTCHA Enterprise and the Google
                Privacy Policy and Terms of Service apply.
              </span>
            </div>
          </form>
        </div>
      </section>
    </main>
  );
};

export default SignupComp;
