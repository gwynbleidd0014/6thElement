"use server";

import { UserInfo, UserLoginInfo } from "@/types/user-type";

export async function registerAction(userInfo: UserInfo) {
  try {
    const response = await fetch("http://192.168.0.20:5141/User/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userInfo),
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Registration failed:", error);
    throw error;
  }
}

export async function loginAction(userInfo: UserLoginInfo) {
  try {
    const response = await fetch("http://192.168.0.20:5141/User/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userInfo),
      cache: "no-store",
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Login failed:", error);
    throw error;
  }
}
