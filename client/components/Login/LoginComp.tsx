"use client";

import { loginAction } from "@/lib/actions";
import Image from "next/image";
import Link from "next/link";
import { ChangeEvent, useState } from "react";
import fbIcon from '../../public/assets/icons/facebookIcon.png'
import googleIcon from '../../public/assets/icons/google.png'


const LoginComp = () => {
  const [userInfo, setUserInfo] = useState({
    email: "",
    password: "",
  });
  const [errorMessage, setErrorMassage] = useState("");

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUserInfo({ ...userInfo, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      await loginAction(userInfo);
      setErrorMassage("");
      window.location.reload();
    } catch (error) {
      setErrorMassage("Something went wrong!");
    }
    setTimeout(() => {
      setErrorMassage("");
    }, 3000);
  };
  return (
    <main className="p-8">
      <div className="flex justify-end">
        <Link
          href="/auth/signup"
          className="uppercase text-[#1CB0F6] font-bold text-[16px] p-4 px-6 rounded-2xl border-2 border-[#AFAFAF] hover:bg-[#E5E5E5] duration-300"
        >
          Sign up
        </Link>
      </div>
      <section>
        {errorMessage.length > 0 && (
          <span className="p-2 text-white text-[20px] bg-red-600 rounded animate-fade-in-up items-center">
            {errorMessage}
          </span>
        )}
        <div className="flex flex-col items-center p-6">
          <form
            className="w-[380px] flex flex-col gap-4"
            onSubmit={handleSubmit}
          >
            <h1 className="text-[26px] font-extrabold mt-2 mb-4 text-center text-[#333333]">
              Log in
            </h1>
            <input
              type="text"
              placeholder="Email"
              name="email"
              value={userInfo.email}
              onChange={handleChange}
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            <input
              type="password"
              name="password"
              value={userInfo.password}
              onChange={handleChange}
              placeholder="Password"
              required
              className="p-2 px-4 w-full text-[22px] rounded-md placeholder:text-[#4B4B4B] outline-none focus:ring-2 focus:ring-inset focus:ring-[#1CB0F6] focus:border-[#1CB0F6]"
            />
            <button
              type="submit"
              className="bg-[#1CB0F6] hover:bg-[#77ccf3] duration-300 text-white p-2 py-3 rounded-xl items-center text-center uppercase font-bold tracking-widest w-full"
            >
              log in
            </button>
            <div className="text-[#AFAFAF]">
              <h2 className="flex flex-row flex-nowrap items-center">
                <span className="flex-grow block border-t-2 border-[#AFAFAF]"></span>
                <span className="m-2">OR</span>
                <span className="flex-grow block border-t-2 border-[#AFAFAF]"></span>
              </h2>
            </div>
            <button className="flex gap-2 justify-center bg-white hover:bg-[#AFAFAF] duration-300 text-blue-600 p-2 py-3 rounded-xl items-center text-center font-bold tracking-widest shadow-[0_6px_0] shadow-[#AFAFAF] w-full">
              <Image src={fbIcon} alt="facebook icon" className="w-6 h-6"/> facebook
            </button>
            <button className="flex gap-2 justify-center bg-white hover:bg-[#AFAFAF] duration-300 text-blue-600 p-2 py-3 rounded-xl items-center text-center font-bold tracking-widest shadow-[0_6px_0] shadow-[#AFAFAF] w-full">
            <Image src={googleIcon} alt="Google icon" className="w-6 h-6"/>
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

export default LoginComp;
