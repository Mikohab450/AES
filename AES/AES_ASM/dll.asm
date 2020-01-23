.DATA


.CODE


AESEncryption PROC MsgRef: QWORD, KeyExpRef:QWORD, EncMsgRef:QWORD
	
	mov MsgRef, rcx
	mov KeyExpRef,rdx
	mov EncMsgRef,r8
	mov MsgSize,r9

	pxor xmm15,xmm0
	aesenc xmm15, xmm1 
	aesenc xmm15, xmm2 
	aesenc xmm15, xmm3 
;	aesenc xmm15, xmm4 
;	aesenc xmm15, xmm5 
;	aesenc xmm15, xmm6 
;	aesenc xmm15, xmm7 
;	aesenc xmm15, xmm8
;	aesenc xmm15, xmm9
;	aesenc xmm15, xmm10 
;	aesenc xmm15, xmm11 
;	aesenc xmm15, xmm12
;	aesenc xmm15, xmm13 
;	aesenclast xmm15, xmm14
	ret
AESEncryption ENDP


AESDecryption PROC MsgRef: QWORD, KeyExpRef:QWORD, EncMsgRef:QWORD, MsgSize:QWORD
	
	mov MsgRef, rcx
	mov KeyExpRef,rdx
	mov EncMsgRef,r8
	mov MsgSize,r9

;	pxor xmm15,xmm0
;	aesenc xmm15, xmm1 
;	aesenc xmm15, xmm2 
;	aesenc xmm15, xmm3 
;	aesenc xmm15, xmm4 
;	aesenc xmm15, xmm5 
;	aesenc xmm15, xmm6 
;	aesenc xmm15, xmm7 
;	aesenc xmm15, xmm8
;	aesenc xmm15, xmm9
;	aesenc xmm15, xmm10 
;	aesenc xmm15, xmm11 
;	aesenc xmm15, xmm12
;	aesenc xmm15, xmm13 
;	aesenclast xmm15, xmm14

			

	ret
AESDecryption ENDP
END