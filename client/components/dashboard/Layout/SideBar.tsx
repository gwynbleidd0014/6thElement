"use client";

import Link from "next/link";
import Image from "next/image";
import learnIcon from "../../../public/assets/icons/learnIcon.svg";
import simulateIcon from "../../../public/assets/icons/simulateIcon.svg";
import marketPlaceIcon from "../../../public/assets/icons/marketplaceIcon.svg";
import othersIcon from "../../../public/assets/icons/othersIcon.svg";
import { usePathname } from "next/navigation";
import { useState } from "react";

const SideBar = () => {
  const [otherModal, setOtherModal] = useState(false);
  const pathName = usePathname();

  return (
    <>
      <div className="fixed z-50 w-full xl:w-[300px] xl:h-full bottom-0 xl:bottom-auto border-t-2 xl:border-t-0 xl:border-r-2 bg-white xl:bg-transparent">
        <div className="p-4 flex flex-row xl:flex-col items-center xl:items-start text-center xl:text-left">
          <h1 className="text-[40px] font-bold text-[#1CB0F6] hidden xl:block">
            6th Element
          </h1>
          <div className="w-full pt-2 flex flex-row justify-around xl:flex-col gap-6">
            <Link
              href="/dashboard/learn"
              className={`${
                pathName === "/dashboard/learn"
                  ? "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 border border-[#1CB0F6] p-2 px-4 rounded-xl  text-[#1CB0F6] bg-[#DDF4FF] w-auto xl:w-[240px]"
                  : "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 text-[#777777]"
              }`}
            >
              <Image src={learnIcon} alt="Learn icon" className="w-12 h-12" />{" "}
              <span className="hidden xl:block">Learn</span>
            </Link>
            <Link
              href="/dashboard/simulate"
              className={`${
                pathName === "/dashboard/simulate"
                  ? "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 border border-[#1CB0F6] p-2 px-4 rounded-xl  text-[#1CB0F6] bg-[#DDF4FF] w-auto xl:w-[240px]"
                  : "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 text-[#777777]"
              }`}
            >
              <Image
                src={simulateIcon}
                alt="Simulate icon"
                className="w-12 h-12"
              />{" "}
              <span className="hidden xl:block">Simulate</span>
            </Link>
            <Link
              href="/dashboard/marketplace"
              className={`${
                pathName === "/dashboard/marketplace"
                  ? "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 border border-[#1CB0F6] p-2 px-4 rounded-xl  text-[#1CB0F6] bg-[#DDF4FF] w-auto xl:w-[240px]"
                  : "text-[22px] font-bold flex justify-center xl:justify-start items-center gap-4 text-[#777777]"
              }`}
            >
              <Image
                src={marketPlaceIcon}
                alt="Marketplace icon"
                className="w-12 h-12"
              />{" "}
              <span className="hidden xl:block">Marketplace</span>
            </Link>
            <div
              onClick={() => setOtherModal(!otherModal)}
              className="text-[22px] font-bold text-[#777777] flex justify-center xl:justify-start items-center gap-4 xl:relative cursor-pointer"
            >
              <Image src={othersIcon} alt="Others icon" className="w-12 h-12" />{" "}
              <span className="hidden xl:block">Others</span>
              {otherModal && (
                <div className="absolute xl:top-16 xl:left-8 -top-48 right-0 w-[240px] flex flex-col gap-4 border border-[#1CB0F6] bg-[#DDF4FF] rounded p-4">
                  <Link
                    href="/dashboard/profile"
                    className="bg-[#1CB0F6] rounded-lg p-2 text-black text-center"
                  >
                    Profile
                  </Link>
                  <button className="bg-[#1CB0F6] rounded-lg p-2 text-black text-center">
                    Settings
                  </button>
                  <button>Log out</button>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default SideBar;
