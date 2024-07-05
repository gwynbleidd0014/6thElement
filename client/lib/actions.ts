"use server";

import { UserInfo, UserLoginInfo } from "@/types/user-type";
import { cookies } from "next/headers";

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

    const data = await response.json();

    cookies().set("token", data.token);

    return data;
  } catch (error) {
    console.error("Login failed:", error);
    throw error;
  }
}

export async function logoutAction() {
  cookies().delete("token");
}

export async function getModules() {
  const token = cookies().get("token");

  if (!token) {
    return;
  }

  try {
    const response = await fetch("http://192.168.0.20:5141/Module", {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token.value}`,
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching modules:", error);
  }
}

export async function getQuestions(id: number) {
  const token = cookies().get("token");

  if (!token) {
    return;
  }

  try {
    const response = await fetch(`http://192.168.0.20:5141/Chapter/${id}`, {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token.value}`,
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching modules:", error);
  }
}

export async function getChaptersById(id: number) {
  const token = cookies().get("token");

  if (!token) {
    return;
  }

  try {
    const response = await fetch(`http://192.168.0.20:5141/Module/${id}`, {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token.value}`,
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching modules:", error);
  }
}

export async function getCorrectAnswer(id: number) {
  const token = cookies().get("token");

  if (!token) {
    return;
  }

  try {
    const response = await fetch(
      `http://192.168.0.20:5141/Answer/checkAnswer/${id}`,
      {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token.value}`,
        },
      }
    );

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching modules:", error);
  }
}
