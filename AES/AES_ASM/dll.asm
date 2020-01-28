.DATA
 OSIEM QWORD 8

.CODE


AESEncryption PROC MsgRef: QWORD, KeyExpRef:QWORD, EncMsgRef:QWORD,NumberOfBlocks:QWORD
	
	mov MsgRef, rcx		;przypisanie wskaznika do tablicy danych wejsciowych z rejestru
	mov KeyExpRef,rdx	;przypisanie wskaznika do tablicy kluczy z rejestru
	mov EncMsgRef,r8	;przypisanie wskaznika do tablicy danych wyjsciowych z rejestru
	mov NumberOfBlocks,r9  ;przypisanie wskaznika do tablicy danych wyjsciowych z rejestru


  ;--------------------------------------------
	mov rax,KeyExpRef		;przypisanie kluczy dla kazdej rundy do rejestrow xmm0-xmm14
	movups xmm0,[rax]
		add rax,16			;przeniesienie  sie o 16 bajtow(128 bitow) 
	movups xmm1,[rax]
		add rax,16
	movups xmm2,[rax]
		add rax,16
	movups xmm3,[rax]
		add rax,16
	movups xmm4,[rax]
		add rax,16
	movups xmm5,[rax]
		add rax,16
	movups xmm6,[rax]
		add rax,16
	movups xmm7,[rax]
		add rax,16
	movups xmm8,[rax]
		add rax,16
	movups xmm9,[rax]
		add rax,16
	movups xmm10,[rax]
		add rax,16
	movups xmm11,[rax]
		add rax,16
	movups xmm12,[rax]
		add rax,16
	movups xmm13,[rax]
		add rax,16
	movups xmm14,[rax]
;----------------------------------

	mov rbx,MsgRef			;przypisanie wiadomosci do zaszyfrowania
	mov rax,NumberOfBlocks	;przypisanie liczby iteracji do rejestru rax
	mov rdx,EncMsgRef		;przypisanie referencji na wynik koncowy
	aLOOP:
		movups xmm15 ,[rbx]
		pxor xmm15,xmm0
		aesenc xmm15, xmm1 
		aesenc xmm15, xmm2 
		aesenc xmm15, xmm3 
		aesenc xmm15, xmm4 
		aesenc xmm15, xmm5 
		aesenc xmm15, xmm6 
		aesenc xmm15, xmm7 
		aesenc xmm15, xmm8
		aesenc xmm15, xmm9
		aesenc xmm15, xmm10 
		aesenc xmm15, xmm11 
		aesenc xmm15, xmm12
		aesenc xmm15, xmm13 
		aesenclast xmm15, xmm14
		movups [rdx],xmm15		;zapisanie wyniku
		add rdx,16			;przesuniecie sie wyniku o kolejne 16 bajtow(128 bitow)
		add rbx,16			;przesuniecie sie danych wejsciowych o kolejne 16 bajtow(128 bitow)
		dec rax				
		cmp rax,0
		jne aLOOP
	
	

	ret
AESEncryption ENDP


AESDecryption PROC MsgRef: QWORD, KeyExpRef:QWORD, EncMsgRef:QWORD,NumberOfBlocks:QWORD

	
	mov MsgRef,rcx		;przypisanie wskaznika do tablicy danych wejsciowych z rejestru
	mov KeyExpRef,rdx	;przypisanie wskaznika do tablicy kluczy z rejestru
	mov EncMsgRef,r8	;przypisanie wskaznika do tablicy danych wyjsciowych z rejestru
	mov NumberOfBlocks,r9  ;przypisanie wskaznika do tablicy danych wyjsciowych z rejestru
	

	mov rbx,MsgRef
	movups xmm15 ,[rbx]

;-------------------------------------------
;dla wszystkich kluczy pzoa pierwszym i ostatnim (xmm0 i xmm14)
;wykonywana jest operacja InvCol za pomoca aesimc
;Jest to niezbedne do deszyfrowania szyfrem odwrotnym(ang. Equivalent Inverse Cipher )

	mov rax,KeyExpRef		;przypisanie kluczy dla kazdej rundy do rejestrow xmm0-xmm14
	movups xmm0,[rax]
		add rax,16		;przeniesienie  sie o 16 bajtow(128 bitow) 
	movups xmm1,[rax]
	aesimc xmm1,xmm1
		add rax,16
	movups xmm2,[rax]
	aesimc xmm2,xmm2
		add rax,16
	movups xmm3,[rax]
	aesimc xmm3,xmm3
		add rax,16
	movups xmm4,[rax]
	aesimc xmm4,xmm4
		add rax,16
	movups xmm5,[rax]
	aesimc xmm5,xmm5
		add rax,16
	movups xmm6,[rax]
	aesimc xmm6,xmm6
		add rax,16
	movups xmm7,[rax]
	aesimc xmm7,xmm7
		add rax,16
	movups xmm8,[rax]
	aesimc xmm8,xmm8
		add rax,16
	movups xmm9,[rax]
	aesimc xmm9,xmm9
		add rax,16
	movups xmm10,[rax]
	aesimc xmm10,xmm10
	add rax,16
	movups xmm11,[rax]
	aesimc xmm11,xmm11
		add rax,16
	aesimc xmm12,xmm12
	movups xmm12,[rax]
		add rax,16
		movups xmm13,[rax]
	aesimc xmm13,xmm13
	add rax,16
	movups xmm14,[rax]


	mov rbx,MsgRef			;przypisanie wiadomosci do odszyfrowania
	mov rax,NumberOfBlocks	;przypisanie liczby iteracji do rejestru rax
	mov rdx,EncMsgRef		;przypisanie referencji na wynik koncowy
	bLOOP:
	pxor xmm15,xmm14
	aesdec xmm15, xmm13 
	aesdec xmm15, xmm12
	aesdec xmm15, xmm11 
	aesdec xmm15, xmm10 
	aesdec xmm15, xmm9 
	aesdec xmm15, xmm8 
	aesdec xmm15, xmm7 
	aesdec xmm15, xmm6
	aesdec xmm15, xmm5
	aesdec xmm15, xmm4 
	aesdec xmm15, xmm3 
	aesdec xmm15, xmm2
	aesdec xmm15, xmm1 
	aesdeclast xmm15, xmm0
	movups [rdx],xmm15		;zapisanie wyniku
	add rdx,16		
	add rbx,16
	dec rax
	cmp rax,0
	jne bLOOP
			

	ret
AESDecryption ENDP
END